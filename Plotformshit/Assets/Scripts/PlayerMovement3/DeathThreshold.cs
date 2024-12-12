using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathThreshold : MonoBehaviour
{
    [SerializeField] private float _deathThreshold;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.z <= _deathThreshold)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
