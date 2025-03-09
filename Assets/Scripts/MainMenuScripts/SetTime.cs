using TMPro; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTime : MonoBehaviour
{
    public DataScriptableObject dataObject;
    public TextMeshProUGUI sourceText;
    // Start is called before the first frame update
    void Start()
    {
        int minutes = Mathf.FloorToInt(dataObject.timeElapsed / 60);
        int seconds = Mathf.FloorToInt(dataObject.timeElapsed % 60);
        sourceText.text = string.Format("Final Time: {0:00}:{1:00}", minutes, seconds);
    }
}
