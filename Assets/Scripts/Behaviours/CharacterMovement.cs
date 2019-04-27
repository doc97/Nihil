using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float maxSpeed = 10f;
    
    private Rigidbody2D body;
    private Animator animator;

    private bool isMoving;

    public Transform[] groundPoints;

    public float groundRadius;

    public LayerMask whatIsGround;

    private bool isGrounded;

    private bool jump;

    public float jumpForce;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float movement = Input.GetAxis("Move");
        body.velocity = new Vector2(movement * maxSpeed, body.velocity.y);
        animator.speed = Mathf.Abs(body.velocity.x / maxSpeed);

        isGrounded = IsGrounded();

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

        if ( isGrounded && jump )
        {
            isGrounded = false;
            body.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
    }

    private void OnStop()
    {
        animator.SetBool("IsMoving", false);
    }

    private void OnMove() {
        animator.SetBool("IsMoving", true);
    }

    private void SetFaceDirection(float movement) {
        bool isForward = (transform.localScale.x == 1 && movement > 0) ||
                         (transform.localScale.x == -1 && movement < 0); 
        animator.SetBool("IsForward", isForward);
    }

    private bool IsGrounded()
    {
        if ( body.velocity.y <= 0 )
        {
            foreach ( Transform point in groundPoints )
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for ( int i = 0 ; i < colliders.Length; i++)
                {
                    if ( colliders[i].gameObject != gameObject )
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
