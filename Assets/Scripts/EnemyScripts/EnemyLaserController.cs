using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserController : MonoBehaviour
{
    public float laserSpeed = 3f; // Speed at which the laser moves
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
                // Ignore collisions between the laser and the enemy
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

    void OnTriggerEnter2D( Collider2D collider)
    {
        Health objectHealth = collider.gameObject.GetComponent<Health>();
        
        // If enemy health exists and the object firing the laser is not the one being hit
        if ( objectHealth != null && collider.CompareTag("Player") ) 
        {
            objectHealth.TakeDamage( damage );
            Debug.Log("Player Took a hit of damage");
        }

        // Destroying laser
        Destroy( gameObject );
    }

}
