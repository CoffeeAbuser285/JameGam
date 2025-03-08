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
    {   
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Instantaneous Acceleration
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
