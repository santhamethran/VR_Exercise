using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunctions : MonoBehaviour
{
    public GameObject startVoiceAssistButton;
    public GameObject stopVoiceAssistButton;
    public GameObject voiceAssistSpeaker;
    
    public void OnClickingStartVoiceAssist()
    {
        voiceAssistSpeaker.SetActive(true);
        startVoiceAssistButton.SetActive(false);
        stopVoiceAssistButton.SetActive(true);
    }

    public void OnClickingStopVoiceAssist()
    {
        voiceAssistSpeaker.SetActive(false);
        stopVoiceAssistButton.SetActive(false);
        startVoiceAssistButton.SetActive(true);
    }
}
