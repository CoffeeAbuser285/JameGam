using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireScript : MonoBehaviour
{
    public GameObject laserPrefab; // The laser prefab
    public Transform laserSpawnPoint; // Point from where the laser will spawn
    public float xAxisShift = 0f;
    public float yAxisShift = 0f;
    public int damage = 1;
    public float fireRate = 0.5f;    
    private float nextFireTime = 0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Time.time >= nextFireTime )
        {
            ShootLaser();
            nextFireTime = Time.time + fireRate; // Ensure a delay between shots
        }
    }

    void ShootLaser()
    {
        Vector3 spawnPosition = laserSpawnPoint.position + new Vector3(xAxisShift, yAxisShift, 0);
        GameObject bullet = Instantiate( laserPrefab, spawnPosition, laserSpawnPoint.rotation);

        // Apply velocity to the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = laserSpawnPoint.up * bullet.GetComponent<EnemyLaserRotationControl>().laserSpeed; // Bullet moves in the direction the barrel is pointing
        }
    }
}
