using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    public float bulletSpeed;

    private bool isShooting;

    void Update() {
        if (Input.GetButtonDown("Shoot"))
            isShooting = true;
    }
    void FixedUpdate()
    {
        if (isShooting)
        {
            isShooting = false;
            Shoot();
        }
    }

    private void Shoot() {
        Vector3 direction = calculateBulletDirection();
        Vector3 spawnPos = transform.position;
        GameObject bulletPrefab = Resources.Load("Bullet", typeof(GameObject)) as GameObject;
        spawnBullet(bulletPrefab, spawnPos, direction);
    }

    private Vector3 calculateBulletDirection()
    {
        Vector3 jointPos = transform.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - jointPos;
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
