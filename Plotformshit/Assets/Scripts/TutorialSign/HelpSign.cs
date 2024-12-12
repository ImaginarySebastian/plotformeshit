using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.UIElements;
using PlayerMovement;
using System.ComponentModel;

public class HelpSign : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image GameOverImage;
    [SerializeField] private UIDocument document;
    private GameObject otherGameObject;
    private Movement move;
    private bool inRange;
    private VisualElement root;
    private bool inHelpSign;
    VisualElement test;
    void Start()
    {
        root = document.rootVisualElement;
        GameOverImage.gameObject.SetActive(false);
        otherGameObject = GameObject.FindWithTag("Player");
        move = otherGameObject.GetComponent<Movement>();
        test = root.Q<VisualElement>("Container");
       // test.style.visibility = Visibility.Visible;

    }

    void Update()
    {

        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.Z) && !inHelpSign)
            {
                inHelpSign = true;
                GameOverImage.gameObject.SetActive(true);
                move._playerCanMove = false;
                test.style.visibility = Visibility.Visible;
                root.style.display = DisplayStyle.None;
                

            }
            else if (Input.GetKeyDown(KeyCode.Z) && inHelpSign)
            {
                inHelpSign = false;
                GameOverImage.gameObject.SetActive(false);
                move._playerCanMove = true;
                root.style.display = DisplayStyle.Flex;
                test.style.visibility = Visibility.Visible;
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
