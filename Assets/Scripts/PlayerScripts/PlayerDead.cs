using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
// Update is called once per frame
    void Update()
    {
        if( GetComponent<Health>().checkIfDead() )
        {
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
}
