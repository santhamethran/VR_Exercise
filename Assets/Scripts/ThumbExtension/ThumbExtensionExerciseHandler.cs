using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ThumbExtensionExerciseHandler : MonoBehaviour
{
    public TextMeshProUGUI leftHandCounter,rightHandCounter, subtitleText,exerciseText;
    public bool leftExerciseBool=true;
    int score = 0;
    public GameObject congrats;
    public GameObject shapeL, shapeR;
    public Meta.Voice.Samples.TTSVoices.TTSSpeakerInputTesting ttsSpeakerObject;
    [SerializeField] GameObject correctRealtimeInstructions;
    [SerializeField] GameObject wrongRealtimeInstructions;
    [SerializeField] GameObject bananaSpriteParent;
    public RotatingThumbExtension rte;
  
    public TextMeshProUGUI heading;
    
    public Material[] fruitsMat;

    public GameObject contentHolder;
    public Animator headAnimController;
    public GameObject guidingCylinderCanvas;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        headAnimController.Play("HeadingIntro");
        yield return new WaitForSeconds(5);
        contentHolder.SetActive(true);
        guidingCylinderCanvas.SetActive(true);
        rte.gameObject.SetActive(true);
        TTSCallFunction(0);
        yield return new WaitForSeconds(4);
    }

    public void TTSCallFunction(int subtitleIndex)
    {
        ttsSpeakerObject.SpeakClick(subtitleIndex);
        subtitleText.text = ttsSpeakerObject._queuedText[subtitleIndex];
    }

    public void LeftHandScore() 
    {
        if (leftExerciseBool)
        {
            bananaSpriteParent.transform.GetChild(score).gameObject.SetActive(true);
            score++;
            leftHandCounter.text = score.ToString();
            CheckScore();
        }
    }

    public void RightHandScore()
    {
        if (!leftExerciseBool)
        {
            bananaSpriteParent.transform.GetChild(score).gameObject.SetActive(true);
            score++;
            rightHandCounter.text = score.ToString();
            CheckScore();
        }
    }

    public void CheckScore() { StartCoroutine(CheckScoreCoroutine()); }

    IEnumerator CheckScoreCoroutine() 
    {
        if (score == 5 && leftExerciseBool) 
        {
            contentHolder.SetActive(false);
            guidingCylinderCanvas.SetActive(false);
            rte.gameObject.SetActive(false);
            headAnimController.Play("HeadingExit");
            yield return new WaitForSeconds(1.5f);
            exerciseText.text = "Please switch hands";
            yield return new WaitForSeconds(2);
            headAnimController.Play("HeadingIntro");
            yield return new WaitForSeconds(1.5f);
            exerciseText.text = "Thumb Extension";
            TTSCallFunction(1);
            contentHolder.SetActive(true);
            guidingCylinderCanvas.SetActive(true);
            rte.gameObject.SetActive(true);
            rte.KeepRotating();
            leftHandCounter.gameObject.transform.parent.gameObject.SetActive(false);
            leftExerciseBool = false;
            //shapeL.SetActive(false);
            shapeR.SetActive(true);
            rightHandCounter.gameObject.transform.parent.gameObject.SetActive(true);
            score = 0;
            for (int i = 0; i < bananaSpriteParent.transform.childCount; i++)
            {
                bananaSpriteParent.transform.GetChild(i).gameObject.SetActive(false);
            }
            heading.text = "Right Hand";
            StartCoroutine(CreateDelay());
            
        }

        else if (score == 5 && !leftExerciseBool) 
        {
            rte.gameObject.SetActive(false);
            TTSCallFunction(2);
            shapeR.SetActive(false);
            StartCoroutine(BackToMainScene());
        }
    }

    IEnumerator BackToMainScene()
    {
        contentHolder.SetActive(false);
        guidingCylinderCanvas.SetActive(false);
        headAnimController.Play("HeadingExit");
        yield return new WaitForSeconds(1.5f);
        exerciseText.text = "Exercise completed";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("_Main");
    }

    IEnumerator CreateDelay() 
    {
        yield return new WaitForSeconds(4);
        StartCoroutine(Start());
    }

    public void InstructionsCheck()
    {
        if (rte.leftTouchable && !rte.rightTouchable && leftExerciseBool)
        {
            correctRealtimeInstructions.SetActive(true);
            wrongRealtimeInstructions.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
        if (rte.leftTouchable && !rte.rightTouchable && !leftExerciseBool)
        {
            wrongRealtimeInstructions.SetActive(true);
            correctRealtimeInstructions.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
        if (!rte.leftTouchable && rte.rightTouchable && leftExerciseBool)
        {
            wrongRealtimeInstructions.SetActive(true);
            correctRealtimeInstructions.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
        if (!rte.leftTouchable && rte.rightTouchable && !leftExerciseBool)
        {
            correctRealtimeInstructions.SetActive(true);
            wrongRealtimeInstructions.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
    }

    IEnumerator DisableRealtimePopup()
    {
        yield return new WaitForSeconds(2);
        correctRealtimeInstructions.SetActive(false);
        wrongRealtimeInstructions.SetActive(false);
    }
}
