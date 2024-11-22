using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OPoseExerciceController : MonoBehaviour
{
    [SerializeField] GameObject leftShapes;
    [SerializeField] GameObject rightShapes;
    [SerializeField] GameObject leftShapesCircle;
    [SerializeField] GameObject rightShapesCircle;
    [SerializeField] GameObject congrats;
    [SerializeField] GameObject rightCube;
    [SerializeField] GameObject leftCube;
    [SerializeField] GameObject correctRealtimeInstructions;
    [SerializeField] GameObject wrongRealtimeInstructions;
    [SerializeField] GameObject bananaSpriteParent;
    [SerializeField] GameObject contentHolder;
    [SerializeField] Animator headAnimController;

    public TMP_Text handMessage, headingText;
    public TMP_Text counter;

    int score = 0;
    public bool rightHand = false;
    public TextMeshProUGUI subtitleText;
    public Meta.Voice.Samples.TTSVoices.TTSSpeakerInputTesting ttsSpeakerObject;

    IEnumerator Start() 
    {
        headAnimController.Play("HeadingIntro");
        yield return new WaitForSeconds(5);
        contentHolder.SetActive(true);
        leftShapes.SetActive(true);
        TTSCallFunction(0);

        yield return new WaitForSeconds(8);
        TTSCallFunction(2);
    }

    private void FixedUpdate()
    {
        if (leftCube.GetComponent<Renderer>().material.color == Color.green && rightCube.GetComponent<Renderer>().material.color == Color.red
            && rightHand==true)
        {
            //Incorrect hand instruction display
            correctRealtimeInstructions.SetActive(false);
            wrongRealtimeInstructions.SetActive(true);
            StartCoroutine(DisableRealtimePopup());
        }
        if (leftCube.GetComponent<Renderer>().material.color == Color.red && rightCube.GetComponent<Renderer>().material.color == Color.green
            && rightHand == true)
        {
            //Correct hand instruction display
            wrongRealtimeInstructions.SetActive(false);
            correctRealtimeInstructions.SetActive(true);
            StartCoroutine(DisableRealtimePopup());
        }

        if (leftCube.GetComponent<Renderer>().material.color == Color.green && rightCube.GetComponent<Renderer>().material.color == Color.red
            && rightHand != true)
        {
            //Correct hand instruction display
            wrongRealtimeInstructions.SetActive(false);
            correctRealtimeInstructions.SetActive(true);
            StartCoroutine(DisableRealtimePopup());
        }
        if (leftCube.GetComponent<Renderer>().material.color == Color.red && rightCube.GetComponent<Renderer>().material.color == Color.green
            && rightHand != true)
        {
            //Incorrect hand instruction display
            correctRealtimeInstructions.SetActive(false);
            wrongRealtimeInstructions.SetActive(true);
            StartCoroutine(DisableRealtimePopup());
        }
    }

    IEnumerator DisableRealtimePopup()
    {
        yield return new WaitForSeconds(2);
        correctRealtimeInstructions.SetActive(false);
        wrongRealtimeInstructions.SetActive(false);
    }

    public void TrackExerciseLeft()
    {
        bananaSpriteParent.transform.GetChild(score).gameObject.SetActive(true);
        score += 1;
            counter.text = score.ToString();
            if (score == 5)
            {
                ExerciseCompleted();
            }
    }
    public void TrackExerciseRight()
    {
        bananaSpriteParent.transform.GetChild(score).gameObject.SetActive(true);
        score += 1;
        counter.text = score.ToString();
        if (score == 5)
        {
            ExerciseCompleted();
            StartCoroutine(BackToMainScene());
        }
    }

    public void TTSCallFunction(int subtitleIndex)
    {
        ttsSpeakerObject.SpeakClick(subtitleIndex);
        subtitleText.text = ttsSpeakerObject._queuedText[subtitleIndex];
    }

    public void ExerciseCompleted(){
        score = 0;
        //counter.text = "0";
       StartCoroutine(NewSetUp());
        contentHolder.SetActive(false);
    }

    IEnumerator NewSetUp(){
        for (int i = 0; i < bananaSpriteParent.transform.childCount; i++)
        {
            bananaSpriteParent.transform.GetChild(i).gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(3);
        if(rightHand == false){
            leftShapes.SetActive(false);
           
            headAnimController.Play("HeadingExit");
            yield return new WaitForSeconds(1.5f);
            headingText.text = "Please switch hands";
            yield return new WaitForSeconds(2);
            headAnimController.Play("HeadingIntro");
            yield return new WaitForSeconds(1.5f);
            headingText.text = "O Pose";
            TTSCallFunction(3);
            contentHolder.SetActive(true);
            rightShapes.SetActive(true);
            leftShapesCircle.SetActive(false);
            rightShapesCircle.SetActive(true);
            handMessage.text = "Right Hand";
            rightHand = true;
            yield return new WaitForSeconds(5);
            TTSCallFunction(2);
        }
        else if(rightHand != false)
        {
            TTSCallFunction(4);
            rightShapes.SetActive(false);
            rightShapesCircle.SetActive(false);
        } 
    }

    IEnumerator BackToMainScene()
    {
        contentHolder.SetActive(false);
        headAnimController.Play("HeadingExit");
        yield return new WaitForSeconds(1.5f);
        headingText.text = "Exercise completed";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("_Main");
    }
}
