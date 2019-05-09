using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevelAreaTrigger : MonoBehaviour
{
    public GameObject character;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == character)
            Commands.FireFadeOut();
    }
}
