using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform firePosition;

    void Start()
    {
        
    }

    void Update()
    {

    }
    
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.position;
        }
    }
}
