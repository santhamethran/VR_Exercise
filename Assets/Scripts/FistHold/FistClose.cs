using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Oculus.Interaction;
using UnityEngine.SceneManagement;

public class FistClose : MonoBehaviour
{
    public GameObject parentSphere;
    public GameObject ballPrefab;
    //public GameObject[] openPalmPose;
    //public GameObject[] fistPose;
    public GameObject exerciseCompletionPanel;
    public TMP_Text exerciseCounterText;
    public TMP_Text timerText;
    public Color selectedColor;
    public Color normalColor;
    public bool leftPoseBool , rightPoseBool ;
    GameObject go;
    float timer = 0f;
    int exerciseCounter = 0;
    bool timerBool = false,changeColorBool=true;
    public TextMeshProUGUI subtitleText, exerciseText;
    public Meta.Voice.Samples.TTSVoices.TTSSpeakerInputTesting ttsSpeakerObject;
    public GameObject congratsScreen;
    [SerializeField] GameObject correctRealtimeInstructions;
    [SerializeField] GameObject wrongRealtimeInstructions;
    [SerializeField] GameObject bananaSpriteParent;
    float timeRemaining = 0;
    public GameObject timerFillingImage;
    public GameObject timerIndicator;
    public TextMeshProUGUI heading;
    public GameObject ovrHandPrefab;
    public Material mat1, mat2;
    public GameObject contentHolder;
    public Animator headAnimController;

    IEnumerator Start()
    {
        headAnimController.Play("HeadingIntro");
        yield return new WaitForSeconds(3);
        TTSCallFunction(0);
        contentHolder.SetActive(true);
        yield return new WaitForSeconds(5);
        InstantiateBall();
    }

    private void FixedUpdate()
    {
        //exerciseCounterText.text = sphere.transform.position.ToString();
        if (timerBool)
        {
            timer += Time.deltaTime;
            timerText.text = ((int)timer).ToString();
            if (timer < 5.1)
            {
                //timeRemaining += Time.deltaTime;
                //timeText.text = ((int)timeRemaining).ToString();
                timerFillingImage.GetComponent<Image>().fillAmount = timer / 5.1f;
            }
            if (timer >= 5f && changeColorBool)
            {
                changeColorBool = false;
                //go.gameObject.GetComponent<Renderer>().material.color = selectedColor ;
                go.GetComponent<Renderer>().material = mat2;
                timerFillingImage.GetComponent<Image>().fillAmount = 0;
                timeRemaining = 0;
                bananaSpriteParent.transform.GetChild(exerciseCounter).gameObject.SetActive(true);
                exerciseCounter++;
            }
        }
    }

   

    public void TTSCallFunction(int subtitleIndex)
    {
        ttsSpeakerObject.SpeakClick(subtitleIndex);
        subtitleText.text = ttsSpeakerObject._queuedText[subtitleIndex];
    }

    public void InstantiateBall()
    {
        StartCoroutine(InstantiateBallCoroutine());
    }

    IEnumerator InstantiateBallCoroutine()
    { 
        yield return new WaitForSeconds(3);
        go = Instantiate(ballPrefab, parentSphere.transform.position, Quaternion.identity,parentSphere.transform);
        go.GetComponent<Rigidbody>().detectCollisions = false;
        go.GetComponent<Rigidbody>().useGravity = false;
        go.GetComponent<Rigidbody>().isKinematic = true;
       
        yield return new WaitForSeconds(4);
        TTSCallFunction(1);
        
        go.GetComponent<Rigidbody>().detectCollisions = true;
        go.GetComponent<Rigidbody>().useGravity = true;
        go.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(4);
        TTSCallFunction(2);
    }

    public void GestureUnselectedTrigger()
    {

        if (timer >= 5f && exerciseCounter <= 5)
        {
            timerBool = false;
            timer = 0;
            StartCoroutine(DisappearBallCoroutineInitiation());
            
        }
        if (timer <5f)
        {
            timerBool = false;
            timer = 0;
        }
        go.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        timerIndicator.SetActive(false);
        //go.GetComponent<Renderer>().material = mat1;
        //go.GetComponent<SphereCollider>().enabled = false;
        //ovrHandPrefab.GetComponent<OVRCustomSkeleton>()._enablePhysicsCapsules = true;
    }

    IEnumerator DisappearBallCoroutineInitiation()
    {
        yield return StartCoroutine(DisappearBall());
    }

    public void GestureSelectedTrigger()
    {
        if (gameObject.GetComponent<FistClose>().enabled == true)
        {
            timerBool = true;
           go.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            // go.GetComponent<SphereCollider>().enabled = false;
            wrongRealtimeInstructions.SetActive(false);
            correctRealtimeInstructions.SetActive(true);
            StartCoroutine(DisableRealtimePopup());
            timerIndicator.SetActive(true);
            //ovrHandPrefab.GetComponent<OVRCustomSkeleton>()._enablePhysicsCapsules = false;
        } 
    }
    IEnumerator DisableRealtimePopup()
    {
        yield return new WaitForSeconds(2);
        correctRealtimeInstructions.SetActive(false);
        wrongRealtimeInstructions.SetActive(false);
    }
    IEnumerator DisappearBall()
    {
        if (go != null)
        {
            changeColorBool = true;
            go.gameObject.GetComponent<Renderer>().material.color = normalColor;
            
            if (exerciseCounter < 5)
            {
                TTSCallFunction(3);
                yield return new WaitForSeconds(1);
                go.SetActive(false);
                go.GetComponent<Rigidbody>().detectCollisions = false;
                go.GetComponent<Rigidbody>().useGravity = false;
                go.GetComponent<Rigidbody>().isKinematic = true;
                go.GetComponent<Renderer>().material = mat1;
                go.transform.rotation= Quaternion.Euler(0, 0, 0);
                go.transform.position = parentSphere.transform.position;
                yield return new WaitForSeconds(1);
                go.SetActive(true);
                yield return new WaitForSeconds(4);
                TTSCallFunction(1);
               
                go.GetComponent<Rigidbody>().detectCollisions = true;
                go.GetComponent<Rigidbody>().useGravity = true;
                go.GetComponent<Rigidbody>().isKinematic = false;
                exerciseCounterText.text = exerciseCounter.ToString();
                timerText.text = "0";
            }
            else if (exerciseCounter == 5)
            {
                contentHolder.SetActive(false);
                yield return new WaitForSeconds(1);
                GameObject.Destroy(go);
                if (gameObject.name == "LeftHandAnchor")
                {
                    headAnimController.Play("HeadingExit");
                    yield return new WaitForSeconds(1.5f);
                    exerciseText.text = "Please switch hands";
                    yield return new WaitForSeconds(2);
                    headAnimController.Play("HeadingIntro");
                    yield return new WaitForSeconds(1.5f);
                    exerciseText.text = "Fist Stretch";
                    TTSCallFunction(4);
                    contentHolder.SetActive(true);

                    gameObject.GetComponent<FistClose>().enabled = false;
                    GameObject.Find("/OculusInteractionSampleRig/OVRCameraRig/TrackingSpace/RightHandAnchor")
                        .GetComponent<FistClose>().enabled = true;
                    //openPalmPose[1].SetActive(true);
                    //fistPose[0].SetActive(false);
                    heading.text = "Right Hand";
                }

                else if (gameObject.name == "RightHandAnchor")
                {
                    TTSCallFunction(5);
                    exerciseCompletionPanel.SetActive(true);
                    gameObject.GetComponent<FistClose>().enabled = false;
                    //fistPose[1].SetActive(false);
                    StartCoroutine(BackToMainScene());
                }
                for (int i = 0; i < bananaSpriteParent.transform.childCount; i++)
                {
                    bananaSpriteParent.transform.GetChild(i).gameObject.SetActive(false);
                }
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
}
