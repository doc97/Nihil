using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCharacter : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;
        if (tag == "Obstacle" || tag == "Enemy")
            Destroy(gameObject);
    }
}