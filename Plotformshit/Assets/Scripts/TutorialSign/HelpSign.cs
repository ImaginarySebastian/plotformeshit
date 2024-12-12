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
    [SerializeField] private UnityEngine.UI.Image GameOverImage2;
    [SerializeField] private UIDocument document;
    private GameObject otherGameObject;
    private Movement move;
    private bool inRange;
    private VisualElement root;
    private bool inHelpSign;
    private VisualElement test;
    private int imageNumber = 0;
    private bool hasStarted = false;
    void Start()
    {
        root = document.rootVisualElement;
        GameOverImage.gameObject.SetActive(false);
        if(GameOverImage2 != null ) GameOverImage2.gameObject.SetActive(false);
        otherGameObject = GameObject.FindWithTag("Player");
        move = otherGameObject.GetComponent<Movement>();
        test = root.Q<VisualElement>("Container");
        test.style.visibility = Visibility.Visible;
        root.style.display = DisplayStyle.Flex;

    }

    void Update()
    {
        /*if (!hasStarted) 
        {
            root.style.display = DisplayStyle.Flex; 
            test.style.visibility = Visibility.Visible; 
            hasStarted = true;
        }*/

            if (Input.GetKeyDown(KeyCode.Z) && !inHelpSign && inRange)
            {
                switch (imageNumber)
                {
                    case 0:
                        GameOverImage.gameObject.SetActive(true);
                        imageNumber += 1;
                        move._playerCanMove = false;
                        test.style.visibility = Visibility.Hidden;
                        root.style.display = DisplayStyle.None;
                    break;
                    case 1:
                        if (GameOverImage2 != null)
                        {
                            GameOverImage2.gameObject.SetActive(true);
                            imageNumber += 1;
                            move._playerCanMove = false;
                            test.style.visibility = Visibility.Hidden;
                            root.style.display = DisplayStyle.None;
                        }
                        else
                        {
                            imageNumber = 0;
                            GameOverImage.gameObject.SetActive(true);
                            move._playerCanMove = false;
                            test.style.visibility = Visibility.Hidden;
                            root.style.display = DisplayStyle.None;
                        }
                        break;
                    default:
                        GameOverImage.gameObject.SetActive(true);
                        imageNumber = 0;
                        move._playerCanMove = false;
                        test.style.visibility = Visibility.Hidden;
                        root.style.display = DisplayStyle.None;
                        break;
                }
                inHelpSign = true;
            }
        
        else if (Input.GetKeyDown(KeyCode.Z) && inHelpSign)
        {
            switch (imageNumber)
            {
                case 1:
                    GameOverImage.gameObject.SetActive(false);
                    if (GameOverImage2 != null) 
                    { 
                        GameOverImage2.gameObject.SetActive(true);
                        imageNumber += 1;
                    }
                    break;
                case 2:
                    GameOverImage.gameObject.SetActive(false);
                    GameOverImage2.gameObject.SetActive(false);
                    break;
                default:
                    GameOverImage.gameObject.SetActive(false);
                    if (GameOverImage2 != null) 
                    {
                        GameOverImage2.gameObject.SetActive(false);
                    }
                    imageNumber = 0;
                    break;

            }
            inHelpSign = false;
            move._playerCanMove = true;
            root.style.display = DisplayStyle.Flex;
            test.style.visibility = Visibility.Visible;
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
