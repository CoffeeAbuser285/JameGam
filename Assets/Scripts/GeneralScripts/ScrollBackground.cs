using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeed = 0.5f;

    public float startY = 20.4f; //use 20.4f for 2048x2048 images
    public float resetY = 20.4f; //use 20.4f for 2048x2048 images
    private Vector2 offset;
    private Transform backgroundImage;


    // Start is called before the first frame update
    void Start()
    {
        backgroundImage = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        backgroundImage.position += Vector3.down * scrollSpeed * Time.deltaTime;

        if (backgroundImage.position.y <= -resetY) {
            backgroundImage.position = new Vector3(transform.position.x, startY, transform.position.z);
        }
    }
}
