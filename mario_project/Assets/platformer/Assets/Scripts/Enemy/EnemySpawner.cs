using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public float spawnDelay = 2f;  // Delay before spawning the enemy

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine to spawn the enemy
        StartCoroutine(SpawnEnemyAfterDelay());
    }

    // Coroutine to spawn the enemy after a delay
    private IEnumerator SpawnEnemyAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(spawnDelay);

        // Define an offset (e.g., 1 unit to the right and 0 units up)
        Vector3 spawnOffset = new Vector3(-1.5f, 0f, 0f); // Change values as needed
        
        // Instantiate the enemy at the spawner's position plus the offset
        Instantiate(enemyPrefab, transform.position + spawnOffset, Quaternion.identity);
    }
    
}
