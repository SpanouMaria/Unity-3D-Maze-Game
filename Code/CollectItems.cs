using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour {
    public AudioClip collectSound;     // Sound to play when an item is collected
    private AudioSource audioSource;   // Audio source component
    public GameObject collectEffect;   // Visual effect when collecting an item
    public int cherryPoints = 1;       // Points awarded for collecting a cherry
    public int lemonPoints = 2;        // Points awarded for collecting a lemon
    public int orangePoints = 3;       // Points awarded for collecting an orange

    private ScoreManager scoreManager; // Reference to the score manager

    private void Start() {
        // Initialize the audio source
        audioSource = GetComponent<AudioSource>(); 

        // Find the score manager in the scene
        scoreManager = FindObjectOfType<ScoreManager>(); 
    }

    private void OnTriggerEnter(Collider other) {
        // Check if the object is a collectible
        if (other.CompareTag("Collectible")) {
            // Add points based on the type of collectible
            if (other.name.Contains("cherry")) {
                scoreManager.AddScore(cherryPoints);
            } else if (other.name.Contains("lemon")) {
                scoreManager.AddScore(lemonPoints);
            } else if (other.name.Contains("orange")) {
                scoreManager.AddScore(orangePoints);
            }

            // Play visual effect if available
            if (collectEffect != null) {
                GameObject effect = Instantiate(collectEffect, other.transform.position, Quaternion.identity);
                
                // Destroy the effect after 2 seconds
                Destroy(effect, 2f); 
            }

            // Play sound effect if available
            if (collectSound != null && audioSource != null) {
                audioSource.PlayOneShot(collectSound);
            }

            // Destroy the collectible object with a shrinking animation
            StartCoroutine(ShrinkAndDestroy(other.gameObject));
        }

        // Check if the object is a death trap
        if (other.CompareTag("DeathTrap")) {
            // Find the GameManager and trigger the Game Over event
            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null) {
                gameManager.TriggerGameOver();
            }

            // Optionally: Stop movement or destroy the player character
            Destroy(gameObject);
        }
    }

    private IEnumerator ShrinkAndDestroy(GameObject collectible) {
        // Store the original size
        Vector3 originalScale = collectible.transform.localScale; 

        // Duration of the shrinking effect
        float shrinkDuration = 1f; 
        float time = 0;

        while (time < shrinkDuration) {
            if (collectible != null) {
                // Gradually reduce the size of the collectible
                collectible.transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, time / shrinkDuration);
                time += Time.deltaTime;
            } else {
                // Exit the coroutine if the object no longer exists
                yield break; 
            }
            yield return null;
        }

        // Destroy the collectible object after shrinking
        if (collectible != null) {
            Destroy(collectible);
        }
    }
}