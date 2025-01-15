using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBob : MonoBehaviour {
    public float speed = 5.0f;                             // Default movement speed
    private float[] speedLevels = { 2f, 4f, 6f, 8f, 10f }; // Five speed levels
    private int currentSpeedIndex = 2;                     // Starts at the third speed level (6f)
    public float minX = -45f, maxX = 45f;                  // Boundaries for movement along the X-axis
    public float minZ = -45f, maxZ = 45f;                  // Boundaries for movement along the Z-axis
    public LayerMask wallLayer;                            // Layer to detect walls

    void Update() {
        // Check for speed change based on number key input
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentSpeedIndex = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentSpeedIndex = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentSpeedIndex = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4)) currentSpeedIndex = 3;
        if (Input.GetKeyDown(KeyCode.Alpha5)) currentSpeedIndex = 4;

        // Set the current movement speed
        speed = speedLevels[currentSpeedIndex];

        // Determine movement directions based on key inputs
        float moveX = 0, moveZ = 0;

        if (Input.GetKey(KeyCode.I)) moveZ = 3;  // Move forward
        if (Input.GetKey(KeyCode.K)) moveZ = -3; // Move backward
        if (Input.GetKey(KeyCode.J)) moveX = -3; // Move left
        if (Input.GetKey(KeyCode.L)) moveX = 3;  // Move right

        // Calculate movement vector
        Vector3 movement = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Check if the new position collides with walls
        Vector3 checkBoxSize = new Vector3(3.5f, 3.5f, 3.5f);

        // Size of collision check (adjusted for Bob) 
        if (!Physics.CheckBox(newPosition, checkBoxSize, Quaternion.identity, wallLayer)) {
            // Clamp position within maze boundaries
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

            // Apply the new position
            transform.position = newPosition;
        }
    }
}