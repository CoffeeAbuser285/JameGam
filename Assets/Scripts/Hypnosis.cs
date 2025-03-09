using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hypnosis : MonoBehaviour
{
    public float frameTime = 0.1f;
    private float lastUpdate;

    public List<Sprite> frames;

    private int frameIndex;
    private Image _image;

    void Start()
    {
        frameIndex = 0;
        lastUpdate = Time.time;
        _image = gameObject.GetComponent<Image>();
    }


    void Update()
    {
        if (Time.time > lastUpdate + frameTime) {
            lastUpdate = Time.time;
            frameIndex ++;
            if (frameIndex >= frames.Count) {
                frameIndex = 0;
            }
            _image.sprite = frames[frameIndex];
        }
        
    }
}
