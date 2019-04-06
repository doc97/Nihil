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
    private Vector3 initialTargetPosition;

    void Start()
    {
        initialPosition = transform.position;
        initialTargetPosition = target.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 diff = target.transform.position - initialTargetPosition;
        if (ignoreX)
            diff.x = 0;
        if (ignoreY)
            diff.y = 0;
        diff.z = 0;

        transform.position = initialPosition + diff * effect;
    }
}