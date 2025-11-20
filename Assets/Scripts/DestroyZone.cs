using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);
            GameManager.instance.bullets++;

            PlayerFire plfire = GameObject.Find("Player").GetComponent<PlayerFire>();
            plfire.bulletObjectPool.Add(other.gameObject);
        }
        else if(other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);

            EnemyManager enmanager = GameObject.Find("Enemy Manager").GetComponent<EnemyManager>();
            enmanager.enemyObjectPool.Add(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
