using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public LayerMask collisionMask;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (LayerUtil.IsInLayerMask(collisionMask, col.gameObject.layer))
            GameState.DecrementHealth();
    }
}
