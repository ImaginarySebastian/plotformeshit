using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    
    [SerializeField] int PlayerHealth = 3;
    public int coins;
    void Awake()
    {
        int numGameSession = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DamagePlayer()
    {
        if (PlayerHealth > 0)
            {
                PlayerHealth--;
            }

            else
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex);
            }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
