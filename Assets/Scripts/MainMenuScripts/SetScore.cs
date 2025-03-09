using TMPro; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScore : MonoBehaviour
{
    public DataScriptableObject dataObject;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Final Score: " + dataObject.finalScore.ToString();
    }
}
