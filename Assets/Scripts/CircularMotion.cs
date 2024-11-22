using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    public float radius = 2.0f; // Radius of the circular path
    public float speed = 1.0f;  // Speed of movement in radians per second

    private float angle = 0.0f;

    private void Update()
    {
        // Calculate the new position on the circle based on the angle
        float x = Mathf.Sin(angle) * radius;
        float z = Mathf.Cos(angle) * radius;

        // Set the new position of the ball
        transform.position = new Vector3(x, transform.position.y, z);

        // Increment the angle based on time and speed
        angle += speed * Time.deltaTime;

        // Wrap the angle around to keep it within 0 to 2*PI range
        if (angle > Mathf.PI * 2)
        {
            angle -= Mathf.PI * 2;
        }
    }
}

