using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    private float setSpeed = 4f;
    private Rigidbody2D rigidBody;
    private float pixelSize;
    private Vector2 screenBounds;


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
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));

        // Get the current position of the Rigidbody2D
        Vector2 currentPosition = rigidBody.position;

        float screenLeft = screenBounds.x * 0.58f; // constant
        float screenRight = -screenBounds.x * 0.58f;
        float screenBottom = screenBounds.y;
        float screenTop = -screenBounds.y;
        
        if (currentPosition.x < screenLeft)
        {
            currentPosition.x = screenLeft;
        }
        else if (currentPosition.x > screenRight)
        {
            currentPosition.x = screenRight;
        }

        if (currentPosition.y < screenBottom)
        {
            currentPosition.y = screenBottom;
        }
        else if (currentPosition.y > screenTop)
        {
            currentPosition.y = screenTop;
        }

        rigidBody.position = currentPosition;
        
    }
}
