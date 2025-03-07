using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float maxSpeed = 4f;

    private Rigidbody2D rigidBody;


    private Vector2 m_MoveVal;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        var velocity = rigidBody.velocity;

        velocity.x = horizontalInput * moveSpeed;
        velocity.y = verticalInput * moveSpeed;


        // Assign back the changed velocity
        rigidBody.velocity = Vector2.ClampMagnitude(4*velocity, maxSpeed);
    }

}
