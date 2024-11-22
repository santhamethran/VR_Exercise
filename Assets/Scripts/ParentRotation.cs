using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentRotation : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Speed of rotation in degrees per second

    private void Update()
    {
        // Rotate the parent around its Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

