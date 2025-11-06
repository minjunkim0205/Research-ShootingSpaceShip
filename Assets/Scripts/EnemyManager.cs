using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyFactory;
    public float createTime = 1.0f;

    float minTime = 1.0f;
    float maxTime = 5.0f;
    float currentTime = 0.0f;

    void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;
            currentTime = 0;
            createTime = Random.Range(minTime, maxTime);
        }
    }
}
