using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserRotationControl : MonoBehaviour
{
    public float laserSpeed = 3f; // Speed at which the laser moves
    public float laserLifetime = 2f; // How long the laser lasts before being destroyed
    public int damage = 1;
    public float rotationSpeedDeg = 90f;
    public float homingDuration = 1f;
    private Collider2D laserCollider;
    private GameObject player;
    private float degOffset = -90f;
    private float homingTimer = 0f;
    private bool isHoming = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        laserCollider = GetComponent<Collider2D>(); 

        GameObject enemy = GameObject.FindWithTag("Enemy");

        if ( enemy != null )
        {
            Collider2D enemyCollider = enemy.GetComponent<Collider2D>();

            if ( enemyCollider != null )
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
        shootTowardPlayer();
    }

    void OnTriggerEnter2D( Collider2D collider)
    {
        Health objectHealth = collider.gameObject.GetComponent<Health>();
        
        // If enemy health exists and the object firing the laser is not the one being hit
        if ( objectHealth != null && collider.CompareTag("Player") ) 
        {
            objectHealth.TakeDamage( damage );
            Debug.Log("Player Took a hit of damage");

            // Destroying laser
            Destroy( gameObject );
        }
    }

    void shootTowardPlayer()
    {   
        if ( isHoming )
        {
            Vector3 laserPosition = transform.position;
            Vector3 playerPosition = player.transform.position;

            transform.position = Vector2.MoveTowards( laserPosition, playerPosition, laserSpeed * Time.deltaTime );

            // Determining angle of rotation
            float laserCurrentRotationZ = transform.eulerAngles.z;
            float laserTargetRotationDegrees = Mathf.Rad2Deg * Mathf.Atan2( ( laserPosition.y - playerPosition.y ) , ( laserPosition.x - playerPosition.x ) ) + degOffset;
            float newAngle = Mathf.MoveTowardsAngle( laserCurrentRotationZ, laserTargetRotationDegrees, rotationSpeedDeg * Time.deltaTime );
            transform.rotation = Quaternion.Euler( 0, 0, newAngle );
            
            homingTimer += Time.deltaTime;

            // If homing has lasted for the set duration, stop homing
            if (homingTimer >= homingDuration)
            {
                isHoming = false;
            }
        }
        else
        {
            transform.Translate( Vector2.down * laserSpeed * Time.deltaTime );
        }

    }
}
