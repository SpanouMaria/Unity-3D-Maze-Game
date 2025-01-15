using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float moveSpeed = 20f;      // Speed of the camera's movement
    public float rotationSpeed = 85f;  // Speed of the camera's rotation

    void Update() {
        // Handle movement along the X and Z axes
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Handle movement along the Y axis (vertical movement)
        float moveY = 0f;

        if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus)) {
            moveY = moveSpeed * Time.deltaTime; // Move upwards
        } else if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.KeypadPlus)) {
            moveY = -moveSpeed * Time.deltaTime; // Move downwards
        }

        // Apply the movement to the camera
        transform.Translate(new Vector3(moveX, moveY, moveZ), Space.World);

        // Handle rotation around the Y axis (and other potential axes)
        if (Input.GetKey(KeyCode.R)) {
            // Rotate around the Y axis
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self); 
        }
    }
}