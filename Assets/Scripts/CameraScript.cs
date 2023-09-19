using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target; // The target object to orbit around.
    public float orbitSpeed = 3.0f; // Adjust this value to control the orbit speed.
    [SerializeField]
    public float distance = 2.0f; // Distance from the target.
    public float minY = 0.0f; // Minimum vertical angle (degrees).
    public float maxY = 80.0f; // Maximum vertical angle (degrees).

    private float currentRotationX = 0.0f;

    void Update()
    {
        // Get input for camera movement.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the new rotation angles.
        currentRotationX += verticalInput * orbitSpeed;
        currentRotationX = Mathf.Clamp(currentRotationX, minY, maxY);

        // Calculate the new camera position.
        Quaternion rotation = Quaternion.Euler(currentRotationX, transform.eulerAngles.y + horizontalInput * orbitSpeed, 0);
        Vector3 desiredPosition = target.position - (rotation * Vector3.forward * distance);

        if(desiredPosition.y < 2)
            desiredPosition.y = 2;

        // Update camera position and rotation.
        transform.position = desiredPosition;
        transform.LookAt(target);
    }
}
