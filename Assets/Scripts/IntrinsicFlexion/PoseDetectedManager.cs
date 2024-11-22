using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;
using UnityEngine.SceneManagement;

public class PoseDetectedManager : MonoBehaviour
{
    public bool gestureLeftBool = false,gestureRightBool=false,handSwitchBool=false;
    public TextMeshProUGUI _instructions, exerciseText;
    int score = 0;
    int cubeCount = 5; //as determined by user and adjusted in portal script
    public GameObject gestureLeft, gestureRight, congratsScreen;
    public TextMeshProUGUI subtitleText;
    public Meta.Voice.Samples.TTSVoices.TTSSpeakerInputTesting ttsSpeakerObject;
    public PortalScript ps;
    public GameObject portal;
    [SerializeField] GameObject correctRealtimeInstructions;
    [SerializeField] GameObject wrongRealtimeInstructions;
    [SerializeField] GameObject bananaSpriteParent;
    public GameObject contentHolder;
    public Animator headAnimController;

    IEnumerator Start() {
        headAnimController.Play("HeadingIntro");
        yield return new WaitForSeconds(5);
        contentHolder.SetActive(true);
        TTSCallFunction(0);
        yield return new WaitForSeconds(12);
        ps.SpawnObjectFunctions();
    }

    public void GestureOnRight() {
        gestureRightBool = true;
       
    }

    public void GestureOffRight() {
        gestureRightBool = false;
    }

    public void GestureOnLeft()
    {
        gestureLeftBool = true;

    }

    public void GestureOffLeft()
    {
        gestureLeftBool = false;
    }

    public void ScoreLeft() { StartCoroutine(ScoreLeftCoroutine()); }

    IEnumerator  ScoreLeftCoroutine()
    {
        bananaSpriteParent.transform.GetChild(score).gameObject.SetActive(true);
        score++;
        if (score <= 5)
        {
            //_instructions.text = "Left Hand: " + score + " / 5";
            if (score == 5)
            {
                contentHolder.SetActive(false);
                headAnimController.Play("HeadingExit");
                yield return new WaitForSeconds(1.5f);
                exerciseText.text = "Please switch hands";
                yield return new WaitForSeconds(2);
                headAnimController.Play("HeadingIntro");
                yield return new WaitForSeconds(1.5f);
                exerciseText.text = "Intrinsic Flexion";
                TTSCallFunction(2);
                contentHolder.SetActive(true);

                score = 0;
                ps.gameObject.SetActive(false);
                _instructions.text = "Right Hand";
               
                gestureLeftBool = false;
                //gestureLeft.SetActive(false);
                //gestureRight.SetActive(true);
                handSwitchBool = true;
                StartCoroutine(PortalDelayedActivate());
                for (int i = 0; i < bananaSpriteParent.transform.childCount; i++)
                {
                    bananaSpriteParent.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
    }

    public void ScoreRight()
    {
        bananaSpriteParent.transform.GetChild(score).gameObject.SetActive(true);
        score++;
        if (score <= 5)
        {
            //_instructions.text = "Right Hand: " + score + " / 5";
            if (score == 5)
            {
                StartCoroutine(BackToMainScene());
                TTSCallFunction(3);
                ps.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator BackToMainScene()
    {
        contentHolder.SetActive(false);
        headAnimController.Play("HeadingExit");
        yield return new WaitForSeconds(1.5f);
        exerciseText.text = "Exercise completed";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("_Main");
    }

    public void TTSCallFunction(int subtitleIndex)
    {
        ttsSpeakerObject.SpeakClick(subtitleIndex);
        subtitleText.text = ttsSpeakerObject._queuedText[subtitleIndex];
    }
 
    public void UpdateScore() {
        //_instructions.text = score < 5 ? "Left Hand: " + (score+1) + " / 5" : "Right Hand: " + (score - 4) + " / 5";
        
        if (score <= 5)
        {
            //_instructions.text = "Left Hand: " + score + " / 5";
            if (score == 5)
            {
                ps.gameObject.SetActive(false);
               // _instructions.text = "Right Hand: 0 / 5";
                TTSCallFunction(2);
                //gestureLeft.SetActive( false);
                //gestureRight.SetActive( true);
                StartCoroutine(PortalDelayedActivate());
            }
        }
        else if (score > 5)
        {
            //_instructions.text = "Right Hand: " + (score-5) + " / 5";
            if (score == 10)
            {
                TTSCallFunction(3);
                congratsScreen.SetActive(true);
                ps.gameObject.SetActive(false);
            }
        } 
    }
    IEnumerator DelayedInstruction()
    {
        yield return new WaitForSeconds(9f);
        TTSCallFunction(1);
    }
    IEnumerator PortalDelayedActivate()
    {
        yield return new WaitForSeconds(5f);
        ps.gameObject.SetActive(true);
        ps.SpawnObjectFunctions();
    }

    public void InstructionsCheck()
    {
        if (gestureLeftBool && !gestureRightBool && !handSwitchBool)
        {
            correctRealtimeInstructions.SetActive(true);
            wrongRealtimeInstructions.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
        if (gestureLeftBool && !gestureRightBool && handSwitchBool)
        {
            wrongRealtimeInstructions.SetActive(true);
            correctRealtimeInstructions.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
        if (!gestureLeftBool && gestureRightBool && !handSwitchBool)
        {
            wrongRealtimeInstructions.SetActive(true);
            correctRealtimeInstructions.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
        if (!gestureLeftBool && gestureRightBool && handSwitchBool)
        {
            correctRealtimeInstructions.SetActive(true);
            wrongRealtimeInstructions.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
    }

    IEnumerator DisableRealtimePopup()
    {
        yield return new WaitForSeconds(3);
        correctRealtimeInstructions.SetActive(false);
        wrongRealtimeInstructions.SetActive(false);
    }
}

