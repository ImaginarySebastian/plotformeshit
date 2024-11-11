using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    float horizontal;
    [SerializeField] float speed = 8f;
    [SerializeField] float jumpSpeed = 16f;
    bool isFacingRight = true;

    void Update()
    {
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);

       if(!isFacingRight && horizontal > 0f) 
       {
            Flip();
       }
       else if (isFacingRight && horizontal <0f)
       {
            Flip();
       }
    }

    public void Jump(InputAction.CallbackContext context) 
    {
        if(context.performed && IsGrounded()) 
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
        }

        if (context.canceled && rigidbody.velocity.y > 0f) 
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded() 
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
    }

    private void Flip() 
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context) 
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
