using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextColorAnimate : MonoBehaviour
{
    public TMP_Text _text;
    public List<Color> colors;

    void Start()
    {
        _text = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Color lerpedColor = Color.Lerp(colors[0], colors[1], Mathf.PingPong(Time.time * 2, 1));
        _text.color = lerpedColor;
        // _text.faceColor = lerpedColor;
    }
}
