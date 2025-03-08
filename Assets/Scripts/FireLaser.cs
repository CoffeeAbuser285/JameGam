using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour
{
    public GameObject laserPrefab; // The laser prefab
    public Transform laserSpawnPoint; // Point from where the laser will spawn
    public float yAxisShift = 0.2f;
    public int damage = 1;
    public float fireRate = 0.2f;    
    private float nextFireTime = 0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            ShootLaser();
            nextFireTime = Time.time + fireRate; // Ensure a delay between shots
        }
    }

    void ShootLaser()
    {
        Vector3 spawnPosition = laserSpawnPoint.position + new Vector3(0, yAxisShift, 0);
        Instantiate( laserPrefab, spawnPosition, Quaternion.identity);
    }

    void OnCollisionEnter2D( Collision2D collision)
    {
        Health objectHealth = collision.gameObject.GetComponent<Health>();
        
        if ( objectHealth != null )
        {
            objectHealth.TakeDamage( damage );
        }

        // Destroying laser
        Destroy( gameObject );
    }
}
