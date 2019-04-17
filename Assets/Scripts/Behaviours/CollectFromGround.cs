using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFromGround : MonoBehaviour
{

    public Transform character;
    public float distanceThreshold = 5;
    public float maxSpeed = 15;

    private Rigidbody2D body;
    private float initialGravity;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        initialGravity = body.gravityScale;
    }
    
    void FixedUpdate()
    {
        Vector3 distance = (character.position - transform.position);
        float speedPercent = Mathf.Clamp01((distanceThreshold - distance.magnitude) / distanceThreshold);
        float velocity = Mathf.Lerp(0, maxSpeed, speedPercent);
        bool isBeingCollected = velocity != 0;

        // Disable gravity when being collected
        body.gravityScale = isBeingCollected ? 0 : initialGravity;
        if (isBeingCollected)
            body.velocity = distance.normalized * velocity;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.transform == character)
        {
            GameState.IncrementScrap();
            Destroy(gameObject);
        }
    }
}
