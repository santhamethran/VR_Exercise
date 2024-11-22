using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingThumbExtension : MonoBehaviour
{


    public bool rightTouchable = false,leftTouchable=false;
    public bool thumbOpen = true;
    public bool LeftRotation = true;
    public float rotationSpeed = 40.0f;

    // Speed of rotation in degrees per second

    private void Update()
    {
        // Rotate the parent around its Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    public void StopRotating(){
        rotationSpeed = 0f;
    }

    public void KeepRotating(){
            rotationSpeed = 40f;
    }

    public void CorrectPoseRight(){
        rightTouchable = true;
    }

    public void NoPoseRight(){
        rightTouchable = false;
    }
    public void CorrectPoseLeft()
    {
        leftTouchable = true;
    }

    public void NoPoseLeft()
    {
        leftTouchable = false;
    }
}
