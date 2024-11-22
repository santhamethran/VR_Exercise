using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectHandling : MonoBehaviour
{
    bool pose = false;
    bool timerOn = false;
    bool isTouchingCylinder = true;
    float time = 0f;
    float timeRemaining = 0;
    public GameObject parentRotation;
    public GameObject exerciseController;
    public GameObject timerIndicator;
    //public Material cylinderMat;
    public GameObject timerFillingImage;
    public TextMeshProUGUI timeText;
    public Material mat1, mat2;
    private Animator anim;
    public OPoseExerciceController opec;

    IEnumerator  Start()
    {
        anim = GetComponent<Animator>();
        if (opec.rightHand == true)
        {
            anim.Play("BananaZoomRight");
            yield return new WaitForSeconds(1.5f);
            anim.Play("BananaFloatRight");
        }
        else
        {
            anim.Play("BananaZoom");
            yield return new WaitForSeconds(1.5f);
            anim.Play("BananaFloat");
        }
        
        
    }

    private void OnCollisionEnter(Collision other){
        if(pose){
            //parentRotation.GetComponent<ParentRotationOShape>().StopRotating();
            isTouchingCylinder = true;
        }
    }

    private void FixedUpdate(){
        if (timerOn){
            time += Time.deltaTime;
            if (timeRemaining < 5.1)
            {
                timeRemaining += Time.deltaTime;
                //timeText.text = ((int)timeRemaining).ToString();
                timerFillingImage.GetComponent<Image>().fillAmount = timeRemaining / 5.1f;
            }
            if (time >= 5.0f){
                if(!exerciseController.GetComponent<OPoseExerciceController>().rightHand /*&& isTouchingCylinder*/)
                {
                    exerciseController.GetComponent<OPoseExerciceController>().TrackExerciseLeft();
                }
                else if (exerciseController.GetComponent<OPoseExerciceController>().rightHand /*&& isTouchingCylinder*/)
                {
                    exerciseController.GetComponent<OPoseExerciceController>().TrackExerciseRight();
                }
                timerFillingImage.GetComponent<Image>().fillAmount = 0;
                //timeText.text = "0";
                gameObject.GetComponent<Renderer>().material = mat2;
                time = 0f;
                timerIndicator.SetActive(false);
                timeRemaining = 0;
            }
        }
    }

    public void DisableAnimator()
    {
        anim.enabled = false;
        timeText.text = "Anim disabled";
    }

    public void EnableAnimator()
    {
        timeText.text = "Anim disabled";
        anim.enabled=true;
        if (opec.rightHand == true)
        {
            anim.Play("BananaFloatRight");
        }
        else
        {
            anim.Play("BananaFloat");
        }   
    }

    private void OnCollisionExit(Collision other){
        //parentRotation.GetComponent<ParentRotationOShape>().KeepRotating();
        gameObject.transform.position = transform.parent.position;
        gameObject.transform.rotation = transform.parent.rotation;
        gameObject.GetComponent<Renderer>().material= mat1;
        isTouchingCylinder = false;
    }
    

    public void Pose(){
        pose = true;
        timerOn = true;
        timerIndicator.SetActive(true);
    }

    public void NoPose(){
        pose = false;
        timerOn = false;
        time = 0f;
        timerFillingImage.GetComponent<Image>().fillAmount = 0;
        timeText.text = "0";
        timerIndicator.SetActive(false);
        timeRemaining = 0;
    }
}
