using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rigidbody;
    bool isGrounded;
    [SerializeField] float jumpSpeed;
    [SerializeField] float moveSpeed;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();    
    }
    void OnJump() 
    {
        if (isGrounded) 
        {
            rigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }
    void OnMove(InputValue value) 
    {
        moveInput = value.Get<Vector2>();
    }
    void Update()
    {
        rigidbody.velocity = moveInput * moveSpeed;    
    }
}
