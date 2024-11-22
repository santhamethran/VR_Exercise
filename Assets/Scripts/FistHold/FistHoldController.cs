using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistHoldController : MonoBehaviour
{
    public GameObject correctRealtimeInstructions;
    public GameObject wrongRealtimeInstructions;
    private bool leftPoseBool;
    public GameObject leftFistPose;
    public GameObject rightFistPose;
    public GameObject leftHandAnchor;
    //public GameObject rightHandAnchor;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

    public void OnFistClose()
    {
        if (leftFistPose.gameObject.GetComponent<Renderer>().material.color == Color.red &&
         rightFistPose.gameObject.GetComponent<Renderer>().material.color == Color.green &&
         leftHandAnchor.GetComponent<FistClose>().enabled == true)
        {
            wrongRealtimeInstructions.SetActive(true);
            correctRealtimeInstructions.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
        if (leftFistPose.gameObject.GetComponent<Renderer>().material.color == Color.green &&
           rightFistPose.gameObject.GetComponent<Renderer>().material.color == Color.red &&
           leftHandAnchor.GetComponent<FistClose>().enabled == true)
        {
            wrongRealtimeInstructions.SetActive(false);
            correctRealtimeInstructions.SetActive(true);
            StartCoroutine(DisableRealtimePopup());
        }
        if (rightFistPose.gameObject.GetComponent<Renderer>().material.color == Color.red &&
           leftFistPose.gameObject.GetComponent<Renderer>().material.color == Color.green &&
           leftHandAnchor.GetComponent<FistClose>().enabled == false)
        {
            wrongRealtimeInstructions.SetActive(true);
            correctRealtimeInstructions.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
        if (rightFistPose.gameObject.GetComponent<Renderer>().material.color == Color.green &&
          leftFistPose.gameObject.GetComponent<Renderer>().material.color == Color.red &&
          leftHandAnchor.GetComponent<FistClose>().enabled == false)
        {
            wrongRealtimeInstructions.SetActive(false);
            correctRealtimeInstructions.SetActive(true);
            StartCoroutine(DisableRealtimePopup());
        }
    }

    IEnumerator DisableRealtimePopup()
    {
        yield return new WaitForSeconds(2);
        correctRealtimeInstructions.SetActive(false);
        wrongRealtimeInstructions.SetActive(false);
    }

    public void OnObjectSelected()
    {
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }

    public void OnObjectUnSelected()
    {
        gameObject.GetComponent<SphereCollider>().enabled = true;
    }
}
