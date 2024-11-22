using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentRotationOShape: MonoBehaviour
{

    public float rotationSpeed = 90.0f; // Speed of rotation in degrees per second
    public GameObject exerciceController;

    private void Update()
    {
        // Rotate the parent around its Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    public void KeepRotating()
    {
        rotationSpeed = 90.0f;
       // exerciceController.GetComponent<ExerciceController>().TTSCallFunction(1);
        //ec.TTSCallFunction(1);
    }

    public void StopRotating()
    {
       // exerciceController.GetComponent<ExerciceController>().TTSCallFunction(2);
        //ec.TTSCallFunction(2);
        rotationSpeed = 0.0f;
    }

}

