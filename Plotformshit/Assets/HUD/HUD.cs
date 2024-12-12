using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    VisualElement root;
    VisualElement test;

    void Awake()
    {
        root = hud.GetComponent<UIDocument>().rootVisualElement;
        test = root.Q<VisualElement>("Container");
        
    }
    
    void Start()
    {
        test.style.visibility = Visibility.Visible;
    }


    void Update()
    {
        Label levelName = root.Q<Label>("Level");
        Label CoinAmmount = root.Q<Label>("Coins");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int val = FindObjectOfType<GameSession>().coins;
        levelName.text = ("Level " + currentSceneIndex.ToString());
        CoinAmmount.text = ("Coins: " + val.ToString());
    }
}
