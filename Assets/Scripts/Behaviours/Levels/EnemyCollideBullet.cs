using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollideBullet : MonoBehaviour
{
    public int lifeEnemy = 100;

    public Transform player;

    public float minDistance = 8.5f;

    public int bulletSpeed = 32;

    public int timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer ++;
        float distance = (player.position - transform.position).magnitude;
        if (distance < minDistance && timer % 40 == 0 )
        {
            Shoot();
        }
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "CharacterBullet(Clone)")
        {
            lifeEnemy -= 10;
            Destroy(col.gameObject);
            if (lifeEnemy <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

