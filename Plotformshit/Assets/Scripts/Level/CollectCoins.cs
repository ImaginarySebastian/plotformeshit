using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public int coins;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            coins += collision.GetComponent<CoinValue>().coinValue;
            Destroy(collision.gameObject);
        }
    }
}
