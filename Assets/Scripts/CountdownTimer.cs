using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public bool Grabbed;
    public GameObject Congrats, FaceL, FaceR;
    public GameObject[] GestureObjs;
    public int GestureIndex;
    public GameObject leftInteractor, rightInteractor;

    private static string[] textValue = new string[8] 
    {
        "Pinch with Left Thumb and Index Finger",
        "Pinch with Left Thumb and Middle Finger",
        "Pinch with Left Thumb and Ring Finger",
        "Pinch with Left Thumb and Pinkie Finger",
        "Pinch with Right Thumb and Index Finger",
        "Pinch with Right Thumb and Middle Finger",
        "Pinch with Right Thumb and Ring Finger",
        "Pinch with Right Thumb and Pinkie Finger"
    };

    private static string incompleteString = "RELEASE AND TRY AGAIN";
    float currentTime = 0f;
    float startingTime = 5f;
    public bool TimerOn;
    public bool finishedTask;
    public bool onMesh;
    public TextMeshProUGUI subtitleText;
    public Meta.Voice.Samples.TTSVoices.TTSSpeakerInputTesting ttsSpeakerObject;

    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TextMeshProUGUI switchText;

    void Start()
    {
        TTSCallFunction(0);
        currentTime = startingTime;
        TimerOn = false;
    }


    public void TTSCallFunction(int subtitleIndex)
    {
        ttsSpeakerObject.SpeakClick(subtitleIndex);
        subtitleText.text = ttsSpeakerObject._queuedText[subtitleIndex];
    }

    IEnumerator Execute()
    {
        while(currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
            yield return new WaitForFixedUpdate();
        }
        if (currentTime <= 0)
        {
            TTSCallFunction(3);
        }
        else if (currentTime >0)
        {
            TTSCallFunction(2);
        }
        finishedTask = true;
        GestureObjs[GestureIndex].SetActive(false);
        GestureIndex++;
        if (GestureIndex < GestureObjs.Length)
        {
            GestureObjs[GestureIndex].SetActive(true);
            if (GestureIndex == 4)
            {
                TTSCallFunction(4);
                //FaceL.SetActive(false);
                //FaceR.SetActive(true);
                leftInteractor.SetActive(false);
                rightInteractor.SetActive(true);
            }
            else
            {
                TTSCallFunction(1);
            }
        }
        else //if (GestureIndex == GestureObjs.Length)
        {
            // Congrats
            TTSCallFunction(5);
            Congrats.SetActive(true);
        }
        StopCountdown();
    }

    public void DiskGrabbed(bool grabbed)
    {
        Grabbed = grabbed;
    }

    public void StartCountdown()
    {
        if(Grabbed)
        {
            TTSCallFunction(2);
            TimerOn = true;
            finishedTask = false;
            switchText.text = string.Empty;
            StartCoroutine(Execute());
        }
    }

    public void StopCountdown()
    {
        StopAllCoroutines();
        TimerOn = false;
        currentTime = 5;
        switchText.text = finishedTask  ? textValue[GestureIndex] : incompleteString;
    }
}
