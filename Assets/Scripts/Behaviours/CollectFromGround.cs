using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFromGround : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Character")
        {
            Destroy(gameObject);
        }
    }
}
