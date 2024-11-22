using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInCircle : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Speed of rotation in degrees per second

    private Vector3 centerPosition; // Center position of the circle

    private void Start()
    {
        centerPosition = transform.parent.position; // Assuming balls are children of a parent GameObject
    }

    private void Update()
    {
        // Calculate the new rotation angle based on time and speed
        float angle = rotationSpeed * Time.deltaTime;

        // Rotate the ball around the center position
        transform.RotateAround(centerPosition, Vector3.up, angle);
    }
}
