using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OculusSampleFramework;

public class TestDebugCanvas : MonoBehaviour
{
    public TMP_Text debugText;
    public OVRHand hand;
    public Transform handTransform;
    public OVRHand.HandFinger finger;


    // Start is called before the first frame update
    void Start()
    {
       // debugText.text = "Test Debug";
    }

    private void Update() {
        //Instructions
        if(hand.IsTracked) {
            /*
            debugText.text = "Hand is being tracked \n";
            debugText.text += "Right Hand Position: " + handTransform.position.ToString() + "\n \n";
            bool isFingerTracked = hand.GetFingerIsPinching(finger);

            debugText.text += "Place Table by pinching Right Middle and Thumb: " + isFingerTracked + "\n\n";
            debugText.text += "Start Game with Right Hand";
            */
        }
    }
}
