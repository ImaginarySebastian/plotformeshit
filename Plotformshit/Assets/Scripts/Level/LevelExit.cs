using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    float  timeUntilLoad = 0f;
    [Tooltip("1 for next, -1 for previous")]
    [SerializeField] int nextOrPrevious;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("NextLevel", timeUntilLoad);
        }
    }
    void NextLevel()
    {
        FindFirstObjectByType<ScenePersist>().ResetScenePersist();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + nextOrPrevious);
    }
}

