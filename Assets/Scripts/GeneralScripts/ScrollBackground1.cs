using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground1 : MonoBehaviour
{
    public float scrollSpeed = 0.5f;

    public float startY = 20.4f; //use 20.4f for 2048x2048 images
    public float resetY = 20.4f; //use 20.4f for 2048x2048 images
    private Material bgMaterial;
    private Vector2 offset;



    // Start is called before the first frame update
    void Start()
    {
        bgMaterial = GetComponent<Renderer>().material;
        offset = bgMaterial.mainTextureOffset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset.y += scrollSpeed * Time.deltaTime;
        bgMaterial.mainTextureOffset = offset;
    }
}
