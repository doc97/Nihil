using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapFountain : MonoBehaviour
{
    [MinMaxRangeAttribute(0, 10)]
    public MinMaxRange speedRange;
    public float initialDelaySec;
    public float delaySec;
    public Transform character;
    public float distanceThreshold = 5;
    public float acceleration = 2;

    private GameObject scrapPrefab;

    void Start()
    {
        scrapPrefab = Resources.Load("Prefabs/Scrap", typeof(GameObject)) as GameObject;
        configurePrefab();
        InvokeRepeating("SpawnScraps", initialDelaySec, delaySec);
    }

    private void configurePrefab()
    {
        CollectFromGround script = scrapPrefab.GetComponent<CollectFromGround>();
        script.Init(character, distanceThreshold, acceleration);
    }

    private void SpawnScraps()
    {
        for (int i = 0; i < 3; i++)
            SpawnScrap();
    }

    private void SpawnScrap()
    {
        float speed = speedRange.GetRandomValue();
        float angle = NihilRandom.Float(45, 135);
        Vector3 direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
        direction.Normalize();

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        GameObject scrapInstance = Instantiate<GameObject>(scrapPrefab, transform.position, rotation);
        Rigidbody2D scrapBody = scrapInstance.GetComponent<Rigidbody2D>();

        scrapBody.velocity = direction * speed;
    }
}