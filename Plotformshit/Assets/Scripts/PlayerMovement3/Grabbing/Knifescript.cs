using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knifescript : MonoBehaviour
{
    [SerializeField] float Knifespeed = 10f;
    public GameObject Knife;
    Rigidbody2D rb;

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            var knife = Instantiate(Knife, transform.position, transform.rotation) as GameObject;
           
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Knifespeed, rb.velocity.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if it hits something
        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }

}

