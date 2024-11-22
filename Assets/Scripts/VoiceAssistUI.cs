using System.Collections;
using System.Collections.Generic;
using Meta.WitAi.TTS.Utilities;
using UnityEngine;

public class VoiceAssistUI : MonoBehaviour
{
    [SerializeField] private GameObject voiceAssistButton;
    [SerializeField] private GameObject voiceAssistSilentButton;
    [SerializeField] private GameObject _speaker;

    public void OnVoiceAssistButtonClick()
    {
        _speaker.SetActive(false);
        voiceAssistButton.SetActive(false);
        voiceAssistSilentButton.SetActive(true);
    }

    public void OnVoiceAssistSilentButtonClick()
    {
        voiceAssistSilentButton.SetActive(false);
        _speaker.SetActive(true);
        voiceAssistButton.SetActive(true);
    }
}
