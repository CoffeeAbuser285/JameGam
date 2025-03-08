using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayerAway : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D( Collider2D collider )
    {
        if ( collider.CompareTag("Player")  )
        {
            Vector2 pushDirection = (collider.transform.position - transform.position).normalized;
            collider.transform.position = transform.position + (Vector3)(pushDirection * 1.1f);
        }
        
    }
}
