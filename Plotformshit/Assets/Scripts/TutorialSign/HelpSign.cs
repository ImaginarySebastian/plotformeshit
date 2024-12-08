using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerMovement;

public class HelpSign : MonoBehaviour
{
    [SerializeField] private Image GameOverImage;
    private GameObject otherGameObject;
    private Movement move;
    private bool inRange;
    void Start()
    {
        GameOverImage.gameObject.SetActive(false);
        otherGameObject = GameObject.FindWithTag("Player");
        move = otherGameObject.GetComponent<Movement>();

    }

    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameOverImage.gameObject.SetActive(true);
                move._playerCanMove = false;

            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                GameOverImage.gameObject.SetActive(false);
                move._playerCanMove = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
