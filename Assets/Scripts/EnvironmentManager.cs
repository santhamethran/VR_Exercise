using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using TMPro;

public class EnvironmentManager : MonoBehaviour
{
    public OVRHand hand;
    public Transform handTransform;
    public OVRHand.HandFinger finger;
    public GameObject tableAndCube;
    private bool hasInstantiated = false;
    public Vector3 positionOffset = new Vector3(0,0,0);
    public TMP_Text debugText;

    //public GameObject panel = GameObject.FindWithTag("Speaker");
    //public TTSSpeakerInput tTSpeakerInputScript;
    

    private void Start() {
        //get the script componenet
        //tTSpeakerInputScript = panel.GetComponent<TTSSpeakerInput>();
    }
    // Update is called once per frame
    void Update()
    {
        bool isFingerTracked = hand.GetFingerIsPinching(finger);

        //If Right Index and Thumb are pinched instantiate table once only
        if(isFingerTracked && !hasInstantiated) {
            Vector3 instantiatePosition = handTransform.position + positionOffset;
            //Instantiate Table
            GameObject instantiatedTable = Instantiate(tableAndCube, instantiatePosition, Quaternion.identity);
            //debugText.text += "Table Position: " + instantiatedTable.transform.position.ToString() + "\n \n";

            //speak
            //tTSpeakerInput.SpeakQueuedClick();
            hasInstantiated = true;
        }
    }

    public bool GetHasInstatiated(){
        return hasInstantiated;
    }
}
