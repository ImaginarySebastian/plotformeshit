using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] int PlayerHealth = 3;
    [SerializeField] float InvincibilityTime = 1f;
    bool Invincible = false;

    void DisableInvincibility()
    {
        Invincible = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnimiWall"))
        {
            if (Invincible == true)
            {
                return;
            }

            if (PlayerHealth > 0)
            {
                PlayerHealth--;
                Invincible = true;
                Invoke("DisableInvincibility", InvincibilityTime);
                Debug.Log("PlayerDeath:");
            }

            else
            {
                Destroy(gameObject);
            }

        }
    }

}
