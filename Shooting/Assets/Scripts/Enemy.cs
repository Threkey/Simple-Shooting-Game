using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 5;
    Vector3 dir;

    public GameObject explosionFactory;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        if (player != null) {
            int ranValue = (int)Random.Range(0f, 100f);
            if (ranValue <= 30)
            {
                GameObject target = GameObject.Find("Player");
                dir = target.transform.position - transform.position;
                dir.Normalize();
            }
            else
            {
                dir = Vector3.down;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ScoreManger.instance.Score++;
        GameObject go=Instantiate(explosionFactory);
        go.transform.position = transform.position;

        if (collision.gameObject.name.Contains("Bullet"))
        {
            collision.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
        }
        else if(!collision.gameObject.name.Contains("Cube"))
        {
            Destroy(collision.gameObject);
        }
        gameObject.SetActive(false);
    }
}
