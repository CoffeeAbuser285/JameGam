using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float laserSpeed = -5f; // Speed at which the laser moves
    public float laserLifetime = 2f; // How long the laser lasts before being destroyed

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, laserLifetime);
    }

    // Update is called once per frame
    void Update()
    {   
        transform.Translate(Vector2.up * laserSpeed * Time.deltaTime);
    }
}
