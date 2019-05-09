using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;
        if (tag == "Player" || tag == "Obstacle")
            Destroy(gameObject);
    }
}