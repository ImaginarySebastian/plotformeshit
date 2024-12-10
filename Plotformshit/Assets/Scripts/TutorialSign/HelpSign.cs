using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.UIElements;
using PlayerMovement;

public class HelpSign : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image GameOverImage;
    [SerializeField] private UIDocument document;
    private GameObject otherGameObject;
    private Movement move;
    private bool inRange;
    private VisualElement root;
    void Start()
    {
        root = document.rootVisualElement;
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
                root.style.display = DisplayStyle.None;

            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                GameOverImage.gameObject.SetActive(false);
                move._playerCanMove = true;
                root.style.display = DisplayStyle.Flex;
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
