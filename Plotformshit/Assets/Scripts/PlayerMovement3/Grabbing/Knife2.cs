using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife2 : MonoBehaviour
{
    Rigidbody2D rigidbody = new Rigidbody2D();
    private bool isLethalKnife;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if it hits something
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;


        }
    }
}
