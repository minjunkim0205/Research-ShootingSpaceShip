using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public FixedJoystick joystick;
    public float speed = 5.0f;
    Vector2 moveVector = Vector2.zero;

    void Start()
    {
        
    }

    void Update()
    {
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;
        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0.0f);
        // transform.Translate(Vector3.right * Time.deltaTime);
        //Vector3 direction = new Vector3(moveVector.x, moveVector.y, 0.0f);
        //transform.Translate(direction * speed * Time.deltaTime);
        transform.position += direction * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
        //Debug.Log(moveVector);
    }
}
