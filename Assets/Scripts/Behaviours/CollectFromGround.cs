using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFromGround : MonoBehaviour
{

    public Transform character;
    public float distanceThreshold = 5;
    public float acceleration = 2;

    private Rigidbody2D body;
    private CircleCollider2D circleCollider;
    private float initialGravity;
    private bool isBeingCollected;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        initialGravity = body.gravityScale;
    }
    
    void FixedUpdate()
    {
        Vector3 distance = (character.position - transform.position);
        float distancePercent = Mathf.Clamp01(distance.magnitude / distanceThreshold);

        // Start collecting it as soon as character is within range
        if (distance.magnitude < distanceThreshold)
        {
            // Ignore gravity when being collected
            body.gravityScale = 0;
            // Make it a trigger when being collected to avoid pushing
            // the character upon impact
            circleCollider.isTrigger = true;
            isBeingCollected = true;
        }

        if (isBeingCollected)
        {
            Vector3 velocity3 = distance.normalized * acceleration;
            Vector2 velocity2 = new Vector2(velocity3.x, velocity3.y);
            Vector2 normal = new Vector2(-velocity2.y, velocity3.x).normalized;

            float dot = Vector2.Dot(normal, body.velocity);
            body.velocity += velocity2;
            body.velocity -= normal * dot / 2; // decrease tangential velocity by half
        }
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
