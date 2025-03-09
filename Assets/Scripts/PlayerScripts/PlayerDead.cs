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

// Update is called once per frame
    void Update()
    {
        if( GetComponent<Health>().checkIfDead() )
        {
            SaveData();
            DeathLogic();
        }
    }

    private void DeathLogic()
    {
        // Blow up main character
        // Wait 2 seconds
        //Load Main Menu and transport time and score
        SceneManager.LoadScene("MainMenu");
    }

    private void SaveData()
    {
        dataObject.finalScore = canvas.GetComponent<UiManager>().GetScore();
        dataObject.timeElapsed = canvas.GetComponent<UiManager>().GetTime();
    }
}
