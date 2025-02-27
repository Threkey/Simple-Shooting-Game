using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] GameObject bulletFactory;
    [SerializeField] Transform firePosition;

    [SerializeField] int poolSize = 10;

    public List<GameObject> bulletObjectPool;
    // Start is called before the first frame update
    void Start()
    {
        bulletObjectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            bulletObjectPool.Add(bullet);

            bulletObjectPool[i].SetActive(false);
        }


#if UNITY_ANDROID
        GameObject.Find("Joystick canvans XYBZ").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
        GameObject.Find("Joystick canvans XYBZ").SetActive(false);
#endif

    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
#endif
    }

    public void Fire()
    {
        if (bulletObjectPool.Count > 0)
        {
            GameObject bullet = bulletObjectPool[0];

            bullet.SetActive(true);

            bulletObjectPool.Remove(bullet);

            bullet.transform.position = transform.position;
        }
    }
}