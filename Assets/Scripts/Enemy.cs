using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosionFactory;
    public AudioClip explosionSound;
    public float speed = 5.0f;

    Vector3 direction;

    void Start()
    {
        direction = Vector3.down;

        int randValue = Random.Range(0, 10);
        if (randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            if (target)
            {
                direction = target.transform.position - transform.position;
                direction.Normalize();
            }
        }
    }

    void OnEnable()
    {
        direction = Vector3.down;

        int randValue = Random.Range(0, 10);
        if(randValue < 8)
        {
            GameObject target = GameObject.Find("Player");
            if(target)
            {
                direction = target.transform.position - transform.position;
                direction.Normalize();
            }
        }
    }

    void Update()
    {
        //transform.position += Vector3.down * speed * Time.deltaTime;
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        /*
        GameObject manager = GameObject.Find("GameManager");
        if (manager != null)
        {
            GameManager gm = manager.GetComponent<GameManager>();
            gm.PlayEffectSound(explosionSound);

            gm.SetScore(gm.GetScore() + 1);
        }
        */
        GameManager.instance.PlayEffectSound(explosionSound);
        //GameManager.instance.SetScore(GameManager.instance.GetScore() + 1);
        GameManager.instance.score++;

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        if (collision.gameObject.name.Contains("Bullet"))
        {
            collision.gameObject.SetActive(false);
            GameManager.instance.bullets++;

            PlayerFire plfire = GameObject.Find("Player").GetComponent<PlayerFire>();
            plfire.bulletObjectPool.Add(collision.gameObject);
        }
        else if (collision.gameObject.name.Contains("Player"))
        {
            GameManager.instance.GameOver();
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }
        //Destroy(gameObject);
        gameObject.SetActive(false);

        EnemyManager enmanager = GameObject.Find("Enemy Manager").GetComponent<EnemyManager>();
        enmanager.enemyObjectPool.Add(gameObject);
    }
}
