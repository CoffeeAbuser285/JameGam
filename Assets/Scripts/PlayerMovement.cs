using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float maxSpeed = 4f;
    private Rigidbody2D rigidBody;



    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {   /*
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        var velocity = rigidBody.velocity;

        velocity.x = horizontalInput * moveSpeed;
        velocity.y = verticalInput * moveSpeed;

        rigidBody.velocity = Vector2.ClampMagnitude(100*velocity, maxSpeed);
        */
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (input.magnitude > 0)
        {
            rigidBody.velocity = input.normalized * maxSpeed;
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
    }

}
