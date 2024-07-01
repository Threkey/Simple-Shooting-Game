using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(1);

        if(collision.gameObject.name.Contains("Bullet") || collision.gameObject.name.Contains("Enemy"))
        {
            collision.gameObject.SetActive(false);

            if (collision.gameObject.name.Contains("Bullet"))
            {
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();

                player.bulletObjectPool.Add(collision.gameObject);
            }
            else if (collision.gameObject.name.Contains("Enemy"))
            {
                GameObject emObject = GameObject.Find("EnemyManager");
                EnemyManager manager = emObject.GetComponent<EnemyManager>();

                manager.enemyObjectPool.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(2);

        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);

            if (other.gameObject.name.Contains("Bullet"))
            {
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();

                player.bulletObjectPool.Add(other.gameObject);
            }
        }

    }
}
