using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    [Range(0, 180)]
    public float aimAngleDeg;
    public float bulletSpeed;
    public Transform hand;
    public Transform elbow;
    public Transform shoulder;

    private SpriteRenderer bodySprite;
    private SpriteRenderer armSprite;
    private float shoulderToElbowDistance;
    private float elbowAngleRad;
    private bool isShooting;

    void Start()
    {
        bodySprite = GetComponent<SpriteRenderer>();
        armSprite = shoulder.GetComponent<SpriteRenderer>();

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
        Vector2 jointToMouse = mousePos - jointPos;
        float distance = jointToMouse.magnitude;
        bool flipX = jointToMouse.x < 0;

        float angleRad = Mathf.Asin(Mathf.Sin(elbowAngleRad) * shoulderToElbowDistance / distance)
                    + Mathf.Asin(jointToMouse.y / distance);
        float angleDeg = MathUtil.ClampAngleDeg(angleRad * Mathf.Rad2Deg, aimAngleDeg / 2, -aimAngleDeg / 2);

        if (float.IsNaN(angleDeg))
            shoulder.localRotation = Quaternion.identity;
        else
            shoulder.localRotation = Quaternion.AngleAxis(angleDeg, Vector3.forward);

        // Flip X if we're looking backwards
        transform.localScale = new Vector3(flipX ? -1 : 1, 1, 1);
    }

    private void Shoot() {
        Vector3 direction = calculateBulletDirection();
        GameObject bulletPrefab = Resources.Load("Prefabs/CharacterBullet", typeof(GameObject)) as GameObject;
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
