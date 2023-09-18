using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float movementSpeed = 5.0f; // Adjust this to control the camera movement speed.
    public float sphereRadius = 10.0f; // Set the radius of your sphere.
    public Transform target; // Set the target the camera should look at.

    void Update()
    {
        // Check for key presses and move the camera accordingly.
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }

        // Ensure the camera stays on the sphere's surface.
        transform.position = transform.position.normalized * sphereRadius;

        // Smoothly interpolate the camera's rotation to look at the target.
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.1f);
    }
}
