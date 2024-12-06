using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] float PlayerKnifeSpeed = 10f;
    [SerializeField] GameObject PlayerKnife;
    void Start()
    {
        
    }

    void OnFire()
    {
       GameObject Knife = Instantiate(PlayerKnife, transform.position, transform.rotation);
        Rigidbody2D rb = Knife.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * PlayerKnifeSpeed, ForceMode2D.Impulse);
    }

   
    void Update()
    {
        
    }
}
