using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public GameObject target;
    [Range(0, 1)]
    public float effect;
    public bool ignoreX;
    public bool ignoreY;
    private Vector3 initialPosition;
    private Vector3 initialDistance;

    void Start()
    {
        initialPosition = transform.position;
        initialDistance = target.transform.position - initialDistance;
    }

    void FixedUpdate()
    {
        Vector3 distance = target.transform.position - initialPosition;
        Vector3 diff = distance - initialDistance;
        if (ignoreX)
            diff.x = 0;
        if (ignoreY)
            diff.y = 0;
        diff.z = 0;

        transform.position = initialPosition + diff * effect;
    }
}