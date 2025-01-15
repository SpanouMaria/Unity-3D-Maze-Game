using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour {
    public GameObject[] treasurePrefabs;    // Array of treasure prefabs
    public float spawnInterval = 5f;        // Time interval between spawns
    public float lifetime = 10f;            // Duration for which the treasure exists before disappearing

    private Vector3 GetRandomPosition() {
        Vector3 randomPosition;
        int attempts = 0;

        do {
            // Calculate a random position with a centered offset
            float x = Mathf.Round(Random.Range(-45f, 45f) / 10f) * 10f + 5f; // Offset 5 to achieve (5, 15, 25, ...)
            float z = Mathf.Round(Random.Range(-45f, 45f) / 10f) * 10f + 5f;

            // Position in the center of the grid
            randomPosition = new Vector3(x, 3.5f, z);

            attempts++;

            // If maximum attempts are exceeded, break
            if (attempts > 100) {
                Debug.LogWarning("No valid position found for the treasure.");
                break;
            }
        }

        // Check if the position is free and does not collide with walls
        while (Physics.CheckBox(randomPosition, new Vector3(2.5f, 3.5f, 2.5f), Quaternion.identity, LayerMask.GetMask("Walls")) ||    // Check for walls
        Physics.CheckBox(randomPosition, new Vector3(2.5f, 3.5f, 2.5f), Quaternion.identity, LayerMask.GetMask("DeathTraps")) ||      // Check for traps
        Physics.CheckBox(randomPosition, new Vector3(2.5f, 3.5f, 2.5f), Quaternion.identity, LayerMask.GetMask("Player"))             // Check for player
        );

        return randomPosition;
    }

    private IEnumerator SpawnTreasure() {
        while (true) {
            // Select a random prefab from the list
            GameObject randomPrefab = treasurePrefabs[Random.Range(0, treasurePrefabs.Length)];
            
            // Spawn the treasure with the correct rotation
            Vector3 spawnPosition = GetRandomPosition();

            // Rotate 90 degrees on the Y axis
            GameObject treasure = Instantiate(randomPrefab, spawnPosition, Quaternion.Euler(0, 90, 90)); 

            // Destroy after lifetime seconds
            Destroy(treasure, lifetime);

            // Wait before spawning the next treasure
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void Start() {
        // Start the treasure spawning process
        StartCoroutine(SpawnTreasure());
    }
}