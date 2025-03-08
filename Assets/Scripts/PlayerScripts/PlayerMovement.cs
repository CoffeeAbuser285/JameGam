using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    private float setSpeed = 4f;
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
}
