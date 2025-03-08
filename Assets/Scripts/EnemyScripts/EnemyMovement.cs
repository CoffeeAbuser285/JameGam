using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
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
        rigidBody.velocity = new Vector2( 0, moveSpeed );
    }

}
