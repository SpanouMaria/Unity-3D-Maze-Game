using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrapSpawner : MonoBehaviour {
    public GameObject deathTrapPrefab; // Prefab for the death trap
    public float spawnInterval = 10f;  // Time interval between spawns
    public float minLifetime = 3f;     // Minimum lifetime of the death trap
    public float maxLifetime = 8f;     // Maximum lifetime of the death trap

    private Vector3 GetRandomPosition() {
        Vector3 randomPosition;
        int attempts = 0;

        do {
            // Generate random X and Z positions rounded to nearest 10, then offset by 5
            float x = Mathf.Round(Random.Range(-45f, 45f) / 10f) * 10f + 5f;
            float z = Mathf.Round(Random.Range(-45f, 45f) / 10f) * 10f + 5f;

            // Fixed Y position for traps
            randomPosition = new Vector3(x, 3.5f, z); 

            attempts++;
            if (attempts > 100) {
                Debug.LogWarning("No valid position found for the death trap.");
                
                // Exit if too many attempts are made
                break; 
            }
        }
        while (
            Physics.CheckBox(randomPosition, new Vector3(2.5f, 3.5f, 2.5f), Quaternion.identity, LayerMask.GetMask("Walls")) ||       // Check for walls
            Physics.CheckBox(randomPosition, new Vector3(2.5f, 3.5f, 2.5f), Quaternion.identity, LayerMask.GetMask("Collectible")) || // Check for collectibles
            Physics.CheckBox(randomPosition, new Vector3(2.5f, 3.5f, 2.5f), Quaternion.identity, LayerMask.GetMask("Player"))         // Check for player
        );

        // Return a valid position for the death trap
        return randomPosition; 
    }

    private IEnumerator SpawnDeathTraps() {
        while (true) {
            // Generate a random spawn position
            Vector3 spawnPosition = GetRandomPosition();

            // Spawn a new death trap at the random position
            GameObject deathTrap = Instantiate(deathTrapPrefab, spawnPosition, Quaternion.identity);

            // Determine a random lifetime for the trap and destroy it after that time
            float lifetime = Random.Range(minLifetime, maxLifetime);
            Destroy(deathTrap, lifetime);

            // Wait for the specified spawn interval before spawning the next trap
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void Start() {
        // Start the coroutine to spawn death traps
        StartCoroutine(SpawnDeathTraps());
    }
}