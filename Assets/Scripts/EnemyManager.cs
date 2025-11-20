using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public int poolSize = 10;
    public List<GameObject> enemyObjectPool;
    public Transform[] spawnPoints;

    public GameObject[] enemyFactories;
    public float createTime = 1.0f;

    int spawnCount = 0;

    float minTime = 0.5f;
    float maxTime = 5.0f;
    float currentTime = 0.0f;

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        enemyObjectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            int rand = Random.Range(0, enemyFactories.Length);
            GameObject enemy = Instantiate(enemyFactories[rand]);
            enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            /*
            for(int i = 0; i < poolSize; i++)
            {
                GameObject enemy = enemyObjectPool[i];
                if(enemy.activeSelf == false)
                {
                    enemy.SetActive(true);
                    // enemy.transform.position = transform.position;
                    int index = Random.Range(0, spawnPoints.Length);
                    enemy.transform.position = spawnPoints[index].position;
                    enemy.SetActive(true);
                    break;
                }
            }
            */
            if (enemyObjectPool.Count > 0)
            {
                GameObject enemy = enemyObjectPool[0];
                enemyObjectPool.Remove(enemy);
                int index = Random.Range(0, spawnPoints.Length);
                enemy.transform.position = spawnPoints[index].position;
                enemy.SetActive(true);
            }
            currentTime = 0;
            createTime = Random.Range(minTime, Mathf.Max(1.0f, maxTime-(0.2f*spawnCount)));
            spawnCount++;
        }
    }
}
