using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainer : MonoBehaviour
{
    public Transform character;
    public Sprite emptySprite;
    public int scrapAmount = 3;
    [MinMaxRangeAttribute(0, 10)]
    public MinMaxRange speedRange;
    public LayerMask scrapGround;
    public float scrapDistanceThreshold;
    public float scrapAcceleration;

    private SpriteRenderer spriteRenderer;
    private GameObject scrapPrefab;
    private bool isFilled = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        scrapPrefab = Resources.Load("Prefabs/ScrapInactive", typeof(GameObject)) as GameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isFilled && other.gameObject.transform == character)
            Open();
    }


    private void Open()
    {
        isFilled = false;
        spriteRenderer.sprite = emptySprite;
        SpawnScraps();
    }

    private void SpawnScraps()
    {
        for (int i = 0; i < scrapAmount; i++)
            SpawnScrap();
    }

    private void SpawnScrap()
    {
        float speed = speedRange.GetRandomValue();
        float angle = NihilRandom.Float(45, 135);
        Vector3 direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

        GameObject scrapInstance = Instantiate<GameObject>(scrapPrefab, transform.position, Quaternion.identity);
        Rigidbody2D scrapBody = scrapInstance.GetComponent<Rigidbody2D>();
        ScrapInactive script = scrapInstance.GetComponent<ScrapInactive>();

        script.Init(character, scrapGround, scrapDistanceThreshold, scrapAcceleration);
        scrapBody.velocity = direction.normalized * speed;
    }
}