using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadSafetyInstructionsScript : MonoBehaviour
{
    public GameObject instructionTTS;
    public Meta.Voice.Samples.TTSVoices.TTSSpeakerInputTesting ttsSpeakerObject;
    // Start is called before the first frame update
    void Start()
    {
        instructionTTS.SetActive(false);
        ttsSpeakerObject.SpeakClick(0);
    }
}
