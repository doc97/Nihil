using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFromGround : MonoBehaviour
{

    public Transform character;
    public float distanceThreshold = 5;
    public float maxSpeed = 15;

    private Rigidbody2D body;
    private CircleCollider2D circleCollider;
    private float initialGravity;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        initialGravity = body.gravityScale;
    }
    
    void FixedUpdate()
    {
        Vector3 distance = (character.position - transform.position);
        float speedPercent = Mathf.Clamp01((distanceThreshold - distance.magnitude) / distanceThreshold);
        float velocity = Mathf.Lerp(0, maxSpeed, speedPercent);
        bool isBeingCollected = velocity != 0;

        // Lessen gravity when being collected
        body.gravityScale = isBeingCollected ? 0 : initialGravity;

        // Make it a trigger when being collected to avoid pushing
        // the character upon impact
        circleCollider.isTrigger = isBeingCollected;

        if (isBeingCollected)
            body.velocity = Vector3.Lerp(body.velocity, distance.normalized * velocity, speedPercent);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform == character)
        {
            GameState.IncrementScrap();
            Destroy(gameObject);
        }
    }
}
