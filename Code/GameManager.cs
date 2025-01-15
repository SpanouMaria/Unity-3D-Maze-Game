using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text gameOverText;          // Reference to the Game Over text UI element

    private bool isGameOver = false;   // Flag to check if the game is over

    private void Start() {
        if (gameOverText != null) {
            // Ensure the Game Over text is hidden at the start of the game
            gameOverText.gameObject.SetActive(false);
        }
    }

    public void TriggerGameOver() {
        if (!isGameOver) {
            // Mark the game as over
            isGameOver = true; 

            if (gameOverText != null) {
                // Display the Game Over text
                gameOverText.gameObject.SetActive(true);
            }

            // Freeze the game by setting the time scale to 0
            Time.timeScale = 0;
        }
    }
}