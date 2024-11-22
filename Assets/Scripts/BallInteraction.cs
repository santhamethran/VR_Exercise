using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteraction : MonoBehaviour
{
    public Material defaultMaterial;
    public Material touchedMaterial;

    private MeshRenderer meshRenderer;
    private bool isTouched;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = defaultMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftHand")) // Check the appropriate tag for the VR hand
        {
            isTouched = true;
            meshRenderer.material = touchedMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LeftHand"))
        {
            isTouched = false;
            meshRenderer.material = defaultMaterial;
        }
    }
}

