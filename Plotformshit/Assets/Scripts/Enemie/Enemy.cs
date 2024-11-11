using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemySpeed = 2f;
    Rigidbody2D rigidbody;
    GameObject player;

    void Start()
    {
      rigidbody = GetComponent<Rigidbody2D>();
      player = GameObject.FindWithTag("Player"); 
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(enemySpeed, 0);

        
    }
    void OnTriggerEnter2D(Collider2D collision) 
    {
        enemySpeed = -enemySpeed;
        Flip();
    }
    void Flip() 
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
