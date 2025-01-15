using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text scoreText;   // UI element to display the score
    private int score = 0;   // Variable to keep track of the score

    // Method to add points to the current score
    public void AddScore(int points) {
        score += points;     // Increment score by the given points
        UpdateScoreUI();     // Update the UI to reflect the new score
    }

    // Method to update the score display on the UI
    private void UpdateScoreUI() {
        if (scoreText != null) {
            // Set the score text in the UI
            scoreText.text = "Score: " + score.ToString();
        }
    }
}