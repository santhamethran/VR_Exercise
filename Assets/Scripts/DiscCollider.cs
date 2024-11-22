using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscCollider : MonoBehaviour
{
    private CountdownTimer _cdt;

    private void OnTriggerEnter(Collider other)
    {
        _cdt.onMesh = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _cdt.onMesh = false;
    }
}
