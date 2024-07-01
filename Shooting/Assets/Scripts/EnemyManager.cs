using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyPrefab;

    float currenTime;

    public float minTime = 1;
    public float maxtime = 2;
    public float creatTime = 1;
    public int selectSpawnPoint = 0;
    public int poolSize = 10;

    public List<GameObject> enemyObjectPool;

    [SerializeField] GameObject[] spawnPoints = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
        creatTime = Random.Range(minTime, maxtime);

        enemyObjectPool = new List<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefab);

            enemyObjectPool.Add(enemy);

            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        currenTime += Time.deltaTime;
        if (currenTime > creatTime) {


            if(enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];

                enemy.SetActive(true);

                enemyObjectPool.Remove(enemy);

                selectSpawnPoint = Random.Range(0, spawnPoints.Length);

                enemy.transform.position = spawnPoints[selectSpawnPoint].transform.position;


            }

            currenTime = 0;
            //GameObject go=Instantiate(EnemyPrefab);
            //go.transform.position = spawnPoints[selectSpawnPoint].transform.position;
            creatTime = Random.Range(minTime, maxtime);
        }
    }
}