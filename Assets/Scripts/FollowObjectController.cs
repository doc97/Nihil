using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectController : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset = new Vector3();
    public bool followX = true;
    public bool followY = true;
    public bool followZ = true;

    void LateUpdate()
    {
        Vector3 newPos = target.transform.position + offset;
        float x = followX ? newPos.x : transform.position.x;
        float y = followY ? newPos.y : transform.position.y;
        float z = followZ ? newPos.z : transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}
