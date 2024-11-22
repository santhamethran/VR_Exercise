using System.Collections;
using System.Collections.Generic;
using Oculus.Voice.Demo.UIShapesDemo;
using UnityEngine;

public class ReadInstructionsScript : MonoBehaviour
{
    public Meta.Voice.Samples.TTSVoices.TTSSpeakerInputTesting ttsSpeakerObject;
    // Start is called before the first frame update
    void Start()
    {
        ttsSpeakerObject.SpeakClick(0);
    }
}
