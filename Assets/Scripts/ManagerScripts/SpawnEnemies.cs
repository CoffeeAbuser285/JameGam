using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // The enemy prefab
    public Transform[] spawnPoints; 
    public float spawnInterval = 20f; // Initial spawn interval
    public float spawnIntervalDecrease = 0.05f; // How much to decrease spawn interval over time
    public float minimumSpawnInterval = 5f; // The minimum spawn interval
    private float gameTime = 0f; // To track how long the game has been running

    void Start()
    {
        // Start the spawning process
        StartCoroutine( CreateEnemies() );
    }

    void Update()
    {
        // Increase the game time over time
        gameTime += Time.deltaTime;

        // Decrease the spawn interval over time, but clamp to the minimum interval
        spawnInterval = Mathf.Max(minimumSpawnInterval, spawnInterval - spawnIntervalDecrease * Time.deltaTime);
    }

    IEnumerator CreateEnemies()
    {
        while (true)
        {
            SpawnEnemy();

            // Wait for the current spawn interval
            yield return new WaitForSeconds( spawnInterval );
        }
    }

    void SpawnEnemy()
    {
        // Choose a random spawn point from the array
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Choose a random enemy prefab from the array
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Instantiate the enemy at the random spawn point
        GameObject enemy = Instantiate(randomEnemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        if (enemy != null)
        {
            float difficultyFactor = 1 + gameTime / 100f; // Example difficulty scaling with time
            float health = enemy.GetComponent<Health>().getInitialHealth() * difficultyFactor;
            Debug.Log("Setting Health");
            Debug.Log(health);
            enemy.GetComponent<Health>().setInitialHealth( health );
        }
    }
}
