using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireLaser : MonoBehaviour
{
    public GameObject[] laserPrefab; // The laser prefab
    public Transform laserSpawnPoint; // Point from where the laser will spawn
    public float yAxisShift = 0.2f;
    public int damage = 1;
    public float fireRate = 0.2f;    
    private float nextFireTime = 0f;
    private float boostTime = 5f;
    private float multiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetKey(KeyCode.Space)
        if ( Time.time >= nextFireTime )
        {
            ShootLaser();
            nextFireTime = Time.time + fireRate; // Ensure a delay between shots
        }
    }

    void ShootLaser()
    {
        Vector3 spawnPosition = laserSpawnPoint.position + new Vector3(0, yAxisShift, 0);

        Instantiate( laserPrefab[0], spawnPosition, Quaternion.identity);
        Instantiate( laserPrefab[1], spawnPosition, Quaternion.identity);
        Instantiate( laserPrefab[2], spawnPosition, Quaternion.identity);
    }

    public void IncreaseFireRate( float mult )
    {
        multiplier = mult;

        // Play FireRate Up Audio

        // Increasing FireRate
        fireRate = fireRate / multiplier;
        StartCoroutine( DecreaseFireRate() );
    }

    private IEnumerator DecreaseFireRate()
    {
        yield return new WaitForSeconds( boostTime );

        fireRate = fireRate * multiplier;
    }
}
