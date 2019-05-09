using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public int lifeEnemy = 100;
    public float minDistance = 8.5f;
    public int bulletSpeed = 8;
    public int fireRateTicks = 40;

    private int timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = (player.position - transform.position).magnitude;
        if (distance < minDistance && ++timer % fireRateTicks == 0 )
            Shoot();
    }

       
    private void Shoot()
    {
        Vector3 direction = -Vector3.right;
        GameObject bulletPrefab = Resources.Load("Prefabs/EnemyBullet", typeof(GameObject)) as GameObject;
        spawnBullet(bulletPrefab, transform.position, direction);
    }

    private void spawnBullet(GameObject prefab, Vector3 position, Vector3 direction)
    {
        Quaternion rotation = Quaternion.FromToRotation(Vector3.right, direction);
        GameObject bulletInstance = Instantiate<GameObject>(prefab, position, rotation);
        Rigidbody2D bulletBody = bulletInstance.GetComponent<Rigidbody2D>();
        bulletBody.velocity = direction * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "CharacterBullet(Clone)")
        {
            lifeEnemy -= 10;
            if (lifeEnemy <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

