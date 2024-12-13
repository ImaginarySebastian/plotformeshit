using PlayerMovement;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] float PlayerKnifeSpeed = 20f;
    [SerializeField] GameObject PlayerKnife;
    private GameObject otherGameObject;
    private Movement move;
    bool hasLiftedButton;
    void Start()
    {
        otherGameObject = GameObject.FindWithTag("Player");
        move = otherGameObject.GetComponent<Movement>();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && hasLiftedButton)
        {
            hasLiftedButton = false;
            Vector2 force = new Vector2(2, 0);
            Quaternion knifeRot = PlayerKnife.transform.rotation;
            Quaternion rotation = new Quaternion(knifeRot.x, knifeRot.y, knifeRot.z, knifeRot.w);
            Quaternion reverse = new Quaternion(knifeRot.x, knifeRot.y, -knifeRot.z, knifeRot.w);
            
            
            if (move.isFacingRight)
            {
                GameObject Knife = Instantiate(PlayerKnife, transform.position, rotation);
                Rigidbody2D rb = Knife.GetComponent<Rigidbody2D>();
                rb.AddForce(transform.right * PlayerKnifeSpeed, ForceMode2D.Impulse);
            }
            else
            {
                GameObject Knife = Instantiate(PlayerKnife, transform.position, reverse);
                Rigidbody2D rb = Knife.GetComponent<Rigidbody2D>();
                rb.AddForce(-transform.right * PlayerKnifeSpeed, ForceMode2D.Impulse);
            }
            
        }
        else if (context.canceled)
        {
            hasLiftedButton = true;
        }
    }

   
    void Update()
    {
        
    }
}
