using UnityEngine;

public class ScrapInactive : MonoBehaviour
{
    private LayerMask layerMask;
    private Transform character;
    private float distanceThreshold;
    private float acceleration;
    private CircleCollider2D circleCollider;
    private GameObject scrapPrefab;

    public void Init(Transform character, LayerMask layerMask, float distanceThreshold, float acceleration)
    {
        this.character = character;
        this.layerMask = layerMask;
        this.distanceThreshold = distanceThreshold;
        this.acceleration = acceleration;
    }

    void Start()
    {
        scrapPrefab = Resources.Load("Prefabs/Scrap", typeof(GameObject)) as GameObject;
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            GameObject scrapInstance = Instantiate<GameObject>(scrapPrefab, transform.position, Quaternion.identity);
            CollectFromGround script = scrapInstance.GetComponent<CollectFromGround>();
            script.Init(character, distanceThreshold, acceleration);

            Destroy(gameObject);
        }
    }

}