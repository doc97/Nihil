using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    public float bulletSpeed;
    public Transform hand;
    public Transform elbow;
    public Transform shoulder;

    private float shoulderToElbowDistance;
    private float elbowAngleRad;
    private bool isShooting;

    void Start()
    {
        Vector2 elbowToHand = hand.position - elbow.position;
        Vector2 elbowToShoulder = shoulder.position - elbow.position;
        shoulderToElbowDistance = elbowToShoulder.magnitude;
        elbowAngleRad = Mathf.Deg2Rad * Vector3.Angle(elbowToHand, elbowToShoulder);
    }

    void Update() {
        if (Input.GetButtonDown("Shoot"))
            isShooting = true;
    }

    void FixedUpdate()
    {
        UpdateArmRotation();
        if (isShooting)
        {
            isShooting = false;
            Shoot();
        }
    }

    private void UpdateArmRotation()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 jointPos = shoulder.position;
        float distance = (mousePos - jointPos).magnitude;
        float deltaY = mousePos.y - jointPos.y;

        float angleRad = Mathf.Asin(Mathf.Sin(elbowAngleRad) * shoulderToElbowDistance / distance) + Mathf.Asin(deltaY / distance);
        float angleDeg = angleRad * Mathf.Rad2Deg;
        shoulder.rotation = Quaternion.AngleAxis(angleDeg, Vector3.forward);
    }

    private void Shoot() {
        Vector3 direction = calculateBulletDirection();
        GameObject bulletPrefab = Resources.Load("Prefabs/Bullet", typeof(GameObject)) as GameObject;
        spawnBullet(bulletPrefab, hand.position, direction);
    }

    private Vector3 calculateBulletDirection()
    {
        Vector3 direction = hand.position - elbow.position;
        direction.z = 0;
        return direction.normalized;
    }

    private void spawnBullet(GameObject prefab, Vector3 position, Vector3 direction)
    {
        Quaternion rotation = Quaternion.FromToRotation(Vector3.right, direction);
        GameObject bulletInstance = Instantiate<GameObject>(prefab, position, rotation);
        Rigidbody2D bulletBody = bulletInstance.GetComponent<Rigidbody2D>();
        bulletBody.velocity = direction * bulletSpeed;
    }
}
