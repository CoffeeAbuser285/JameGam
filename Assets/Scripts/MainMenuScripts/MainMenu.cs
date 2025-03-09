using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public AudioSource mainMenu;
    //public DataScriptableObject dataManager;

    void Awake()
    {

    }

    void Start()
    {
        //mainMenu.Play();
    }

    void Update()
    {

    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene"); //loading into game scene
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}


