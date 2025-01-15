using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrapCollision : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        // Check if the object colliding with the trap is the player
        // Assumes the player character (e.g., Bob) has the tag "Player"
        if (other.CompareTag("Player")) {
            // Trigger the Game Over event via the GameManager
            FindObjectOfType<GameManager>().TriggerGameOver();

            // Destroy the player object upon collision
            Destroy(other.gameObject);
        }
    }
}