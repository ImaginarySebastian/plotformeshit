using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    private GameObject gameSession;
    private GameSession gameSessionScript;
    
    public int coinValue;

    private void Awake()
    {
        gameSession = GameObject.FindWithTag("GameSession");
        gameSessionScript = gameSession.GetComponent<GameSession>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            int value = collision.GetComponent<CoinValue>().coinValue;
            gameSessionScript.coins += value;
            coinValue += value;
            Destroy(collision.gameObject);
        }
    }
}
