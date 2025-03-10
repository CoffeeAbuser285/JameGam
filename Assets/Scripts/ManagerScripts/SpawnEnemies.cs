using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // The enemy prefab
    public Transform[] spawnPoints; 
    public string[] enemyLayers;
    public float spawnInterval = 20f; // Initial spawn interval
    public float spawnIntervalDecrease = 0.05f; // How much to decrease spawn interval over time
    public float minimumSpawnInterval = 5f; // The minimum spawn interval
    private float gameTime = 0f; // To track how long the game has been running
    private int numCount = 0;

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

    private void SpawnEnemy()
    {
        // Choose a random spawn point from the array
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Choose a random enemy prefab from the array
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Instantiate the enemy at the random spawn point
        GameObject enemy = Instantiate(randomEnemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        if (enemy != null)
        {
            float difficultyFactor = 1 + 1.5f * ( gameTime / 100f ); // Example difficulty scaling with time
            float health = enemy.GetComponent<Health>().getInitialHealth() * difficultyFactor;
            Debug.Log("Setting Health");
            Debug.Log(health);
            enemy.GetComponent<Health>().setInitialHealth( health );
        }

        // Pick a random layer name from the array of layers
        string randomLayer = enemyLayers[ numCount ];

        // Increment Layer
        IncrementCounter();

        // Optional: If the enemy has child objects, you can also assign the layer to them
        SetLayerRecursively(enemy.transform, randomLayer);
    }

    private void SetLayerRecursively(Transform objTransform, string layer)
    {
        // Check if the object has a TilemapRenderer component
        TilemapRenderer tilemapRenderer = objTransform.GetComponent<TilemapRenderer>();
        if (tilemapRenderer != null)
        {
            tilemapRenderer.sortingLayerName = layer;
            tilemapRenderer.sortingOrder = 0;
        }

        // Check if the object has a SpriteRenderer component
        SpriteRenderer spriteRenderer = objTransform.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingLayerName = layer;
            spriteRenderer.sortingOrder = 1;
        }

        // Recursively call this method for each child
        foreach (Transform child in objTransform)
        {
            SetLayerRecursively(child, layer);
        }
    }

    private void IncrementCounter()
    {
        if ( numCount >= enemyLayers.Length )
        {
            numCount = 0;
        }
        else
        {
            numCount += 1;
        }
    }
}
