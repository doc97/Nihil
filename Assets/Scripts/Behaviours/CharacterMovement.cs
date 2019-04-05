using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float maxSpeed = 10f;
    
    private Rigidbody2D body;
    private Animator animator;

    private bool isMoving;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float movement = Input.GetAxis("Move");
        body.velocity = new Vector2(movement * maxSpeed, body.velocity.y);
        animator.speed = Mathf.Abs(body.velocity.x / maxSpeed);

        if (movement == 0 && isMoving)
        {
            isMoving = false;
            OnStop();
        }

        if (movement != 0 && !isMoving)
        {
            isMoving = true;
            OnMove();
        }

        SetFaceDirection(movement);
    }

    private void OnStop()
    {
        animator.SetBool("IsMoving", false);
    }

    private void OnMove() {
        animator.SetBool("IsMoving", true);
    }

    private void SetFaceDirection(float movement) {
        Vector3 currentScale = transform.localScale;
        currentScale.x = movement == 0 ? currentScale.x : Mathf.Sign(movement);
        transform.localScale = currentScale;
    }
}
