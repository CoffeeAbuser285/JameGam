using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    public DataScriptableObject dataObject;
    private GameObject canvas;

    void Start()
    {
        canvas = GameObject.FindWithTag( "Canvas" );
    }

    public void DeathLogic()
    {
        // Blow up main character
        // Wait 2 seconds
        //Load Main Menu and transport time and score
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveData()
    {
        dataObject.finalScore = canvas.GetComponent<UiManager>().GetScore();
        dataObject.timeElapsed = canvas.GetComponent<UiManager>().GetTime();
    }
}
