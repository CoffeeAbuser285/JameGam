using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    private float setSpeed = 4f;
    private Rigidbody2D rigidBody;
    private float pixelSize;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        pixelSize = Camera.main.orthographicSize * 2 / Screen.height;
    }

    void Update()
    {
        MoveCharacter();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ClampPlayerPosition();
    }

    private void MoveCharacter()
    {   
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Checking whether shift is held down
        if ( Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) )
        {
            setSpeed = moveSpeed / 2;
        }
        else
        {
            setSpeed = moveSpeed;
        }

        // Instantaneous Acceleration
        if (input.magnitude > 0)
        {
            rigidBody.velocity = input.normalized * setSpeed;
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
    }

    private void ClampPlayerPosition()
    {
        // Get screen boundaries in world space
        Camera cam = Camera.main;
        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;

        // Get the current position of the Rigidbody2D
        Vector2 currentPosition = rigidBody.position;

        float screenLeft = -halfWidth;
        float screenRight = halfWidth;
        float screenBottom = -halfHeight;
        float screenTop = halfHeight;

        // Only update position if it's out of bounds, otherwise let the player move freely
        Debug.Log(screenLeft);
        Debug.Log(screenRight);
        Debug.Log(screenTop);
        Debug.Log(screenBottom);
        Debug.Log(currentPosition);

        if (currentPosition.x < screenLeft)
        {
            currentPosition.x = screenLeft;
            rigidBody.position = currentPosition;
        }
        else if (currentPosition.x > screenRight)
        {
            currentPosition.x = screenRight;
            rigidBody.position = currentPosition;
        }

        if (currentPosition.y < screenBottom)
        {
            currentPosition.y = screenBottom;
            rigidBody.position = currentPosition;
        }
        else if (currentPosition.y > screenTop)
        {
            currentPosition.y = screenTop;
            rigidBody.position = currentPosition;
        }
    }
}
