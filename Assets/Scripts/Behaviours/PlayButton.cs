using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private Vector3 hoverOffset = Vector3.right * 0.5f;
    private Vector3 initialPosition;
    private Vector2 initialColliderSize;
    private Vector2 initialColliderOffset;
    private BoxCollider2D collider2d;

    void Start()
    {
        initialPosition = transform.localPosition;
        collider2d = GetComponent<BoxCollider2D>();
        initialColliderSize = collider2d.size;
        initialColliderOffset = collider2d.offset;
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Intro");
        }
    }

    void OnMouseEnter()
    {
        transform.localPosition = initialPosition + hoverOffset;
        collider2d.size = initialColliderSize + (Vector2)hoverOffset;
        collider2d.offset = initialColliderOffset - (Vector2)hoverOffset / 2f;
    }

    void OnMouseExit()
    {
        transform.localPosition = initialPosition;
        collider2d.size = initialColliderSize;
        collider2d.offset = initialColliderOffset;
    }
}
