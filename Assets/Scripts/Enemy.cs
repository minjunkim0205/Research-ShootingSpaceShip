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

    void Update()
    {
        //transform.position += Vector3.down * speed * Time.deltaTime;
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject manager = GameObject.Find("GameManager");
        if (manager != null)
        {
            GameManager gm = manager.GetComponent<GameManager>();
            gm.PlayEffectSound(explosionSound);

            gm.SetScore(gm.GetScore() + 1);
        }

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
