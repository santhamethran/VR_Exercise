using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Completion : MonoBehaviour
{
    [SerializeField] GameObject _congrats;
    [SerializeField] TextMeshProUGUI _scoreL, _scoreR, exerciseText;
    [SerializeField] GameObject rightCube;
    [SerializeField] GameObject leftCube;
    [SerializeField] GameObject rightPopup;
    [SerializeField] GameObject leftPopup;
    [SerializeField] GameObject correctPopup;

    int score_L = 0;
    int score_R = 0;
    int repetition = 10;
    public TextMeshProUGUI subtitleText;
    public Meta.Voice.Samples.TTSVoices.TTSSpeakerInputTesting ttsSpeakerObject;
    public GameObject bananaSpriteParent, contentHolder;
    public Animator headAnimController;

    IEnumerator Start() 
    {
        headAnimController.Play("HeadingIntro");
        yield return new WaitForSeconds(5);
        contentHolder.SetActive(true);
        TTSCallFunction(0);
        yield return new WaitForSeconds(5);
        TTSCallFunction(1);
    }

    private void LateUpdate()
    {
        if ((leftCube.GetComponent<Renderer>().material.color == Color.green) &&
            (rightCube.GetComponent<Renderer>().material.color == Color.green))
        {
            correctPopup.SetActive(true);
            rightPopup.SetActive(false);
            leftPopup.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
        if ((leftCube.GetComponent<Renderer>().material.color == Color.red) &&
            (rightCube.GetComponent<Renderer>().material.color == Color.green))
        {
            correctPopup.SetActive(false);
            rightPopup.SetActive(false);
            leftPopup.SetActive(true);
            StartCoroutine(DisableRealtimePopup());
        }
        if ((leftCube.GetComponent<Renderer>().material.color == Color.green) &&
            (rightCube.GetComponent<Renderer>().material.color == Color.red))
        {
            correctPopup.SetActive(false);
            rightPopup.SetActive(true);
            leftPopup.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
       
    }

    IEnumerator DisableRealtimePopup()
    {
        yield return new WaitForSeconds(2);
        correctPopup.SetActive(false);
        rightPopup.SetActive(false);
        leftPopup.SetActive(false);
    }

    public void TTSCallFunction(int subtitleIndex)
    {
        ttsSpeakerObject.SpeakClick(subtitleIndex);
        subtitleText.text = ttsSpeakerObject._queuedText[subtitleIndex];
    }

    public void LeftScore(){
        bananaSpriteParent.transform.GetChild(score_L).gameObject.SetActive(true);
        score_L++;
        if(score_L >= repetition && score_R >= repetition){
            completed();
        }
    }
    public void RightScore(){
        score_R++;
        if (score_R >= repetition && score_R >= repetition){
            completed();
        }

    }

    public void ScoreDebug()
    {
        _scoreL.text = "collision detected";
            }

    void completed() { StartCoroutine(completedCoroutine()); }

        IEnumerator completedCoroutine(){
        contentHolder.SetActive(false);
        headAnimController.Play("HeadingExit");
        yield return new WaitForSeconds(1.5f);
        exerciseText.text = "Exercise completed";
        TTSCallFunction(2);
        _congrats.SetActive(true);
        gameObject.SetActive(false);
        StartCoroutine(BackToMainScene());
    }

    IEnumerator BackToMainScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("_Main");
    }
}
