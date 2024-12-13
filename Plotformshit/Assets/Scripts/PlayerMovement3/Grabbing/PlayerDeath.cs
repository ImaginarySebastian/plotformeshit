using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDeath : MonoBehaviour
{
    [SerializeField] float InvincibilityTime = 1f;
    GameObject gameSession;
    GameSession gameSessionScript;
    public bool Invincible = false;
    
    void Awake()
    {
        gameSession = GameObject.FindWithTag("GameSession");
        gameSessionScript = gameSession.GetComponent<GameSession>(); 
    }
    void DisableInvincibility()
    {
        Invincible = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (Invincible == true)
            {
                return;
            }
            Invincible = true;
            Invoke("DisableInvincibility", InvincibilityTime);
            gameSessionScript.DamagePlayer();

            
        }
    }

}
