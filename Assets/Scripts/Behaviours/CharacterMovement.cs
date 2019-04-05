using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float maxSpeed = 10f;
    
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float movement = Input.GetAxis("Move");
        body.velocity = new Vector2(movement * maxSpeed, body.velocity.y);

        // Don't change face direction if standing still
        if (movement != 0)
            SetFaceDirection(movement);
    }

    private void SetFaceDirection(float movement) {
        Vector3 currentScale = transform.localScale;
        currentScale.x = Mathf.Sign(movement);
        transform.localScale = currentScale;
    }
}
