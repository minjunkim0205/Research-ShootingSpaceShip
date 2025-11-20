using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePosition;

    public int poolSize = 10;
    public List<GameObject> bulletObjectPool;

    void Start()
    {
        bulletObjectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bulletObjectPool.Add(bullet);
            bullet.SetActive(false);
        }
        GameManager.instance.bullets = poolSize;
    }

    void Update()
    {

    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //GameObject bullet = Instantiate(bulletFactory);
            //bullet.transform.position = firePosition.position;
            /*
            for(int i = 0; i < poolSize; i++)
            {
                GameObject bullet = bulletObjectPool[i];
                if(bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    bullet.transform.position = firePosition.position;
                    GameManager.instance.bullets--;
                    break;
                }
            }
            */
            Fire();
        }
    }

    public void Fire()
    {
        if (bulletObjectPool.Count > 0)
        {
            GameObject bullet = bulletObjectPool[0];
            bulletObjectPool.Remove(bullet);
            bullet.transform.position = firePosition.transform.position;
            bullet.SetActive(true);
            GameManager.instance.bullets--;
        }
    }
}