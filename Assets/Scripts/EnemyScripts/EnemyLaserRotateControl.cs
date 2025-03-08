using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserRotateController : MonoBehaviour
{
    public float laserSpeed = -5f; // Speed at which the laser moves
    public float laserLifetime = 2f; // How long the laser lasts before being destroyed
    public int damage = 1;
    private Collider2D laserCollider;

    // Start is called before the first frame update
    void Start()
    {
        laserCollider = GetComponent<Collider2D>(); 

        GameObject enemy = GameObject.FindWithTag("Enemy");

        if ( enemy != null )
        {
            Collider2D enemyCollider = enemy.GetComponent<Collider2D>();

            if ( enemy != null )
            {
                // Ignore collisions between the laser and the player
                Physics2D.IgnoreCollision(laserCollider, enemyCollider); 
            }
        }

        Destroy(gameObject, laserLifetime);
    }

    // Update is called once per frame
    void Update()
    {   
        transform.Translate(Vector2.down * laserSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D( Collider2D colider)
    {
        Health objectHealth = colider.gameObject.GetComponent<Health>();
        
        // If player health exists and the object firing the laser is not the one being hit
        if ( objectHealth != null && colider.CompareTag("Player") ) 
        {
            objectHealth.TakeDamage( damage );
            Debug.Log("Took a hit of damage");
            Destroy( gameObject );
        }
    }

}
