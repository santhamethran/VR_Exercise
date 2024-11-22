using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskCollision : MonoBehaviour
{
    public GameObject countdownObject;

    private void OnTriggerEnter(Collider other){
        countdownObject.GetComponent<CountdownTimer>().DiskGrabbed(true);
    }

    private void OnTriggerExit(Collider other){
        countdownObject.GetComponent<CountdownTimer>().DiskGrabbed(false);
    }
}
