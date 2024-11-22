using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Curl : MonoBehaviour
{
    public bool Up;
    private int _count;
    [SerializeField]
    private GameObject _cylinder, _obj, _wristL, _wristR, _congrats;
    [SerializeField] private GameObject _gestureL, _gestureR;
    [SerializeField]
    //private MeshRenderer _sphere;
    private Material ripedMat, unripedMat;
    public static string _instructionsL, _instructionsR;
    private Transform _pos;

    private float _timer = 0;
    [SerializeField]
    private TextMeshProUGUI _countTxt, _timerTxt, handText,exerciseText;

    private static float s_size = 0.08f, s_transformed = 0.15f;
    public TextMeshProUGUI subtitleText;
    public Meta.Voice.Samples.TTSVoices.TTSSpeakerInputTesting ttsSpeakerObject;

    [SerializeField] GameObject correctRealtimeInstructions;
    [SerializeField] GameObject wrongRealtimeInstructions;
    [SerializeField] GameObject bananaSpriteParent;
    public GameObject timerFillingImage;
    public GameObject timerIndicator;
    bool r_HandDetectionBool = false, l_HandDetectionBool = false, exerciseStarted=false, handSwitcher=false;
    public GameObject contentHolder;
    public Animator headAnimController;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        headAnimController.Play("HeadingIntro");
        yield return new WaitForSeconds(5);
        contentHolder.SetActive(true);
        TTSCallFunction(0);
        yield return new WaitForSeconds(6);
        TTSCallFunction(1);
        _wristL.SetActive(true);
        _wristR.SetActive(false);
    }

    public void TTSCallFunction(int subtitleIndex)
    {
        ttsSpeakerObject.SpeakClick(subtitleIndex);
        subtitleText.text = ttsSpeakerObject._queuedText[subtitleIndex];
    }

    public void InitTransform(Transform pos)
    {
        if (Up)
        {
            if (pos.name.Contains("b_r_"))
            {
                l_HandDetectionBool = false;
                r_HandDetectionBool = true;
            }
            else if (pos.name.Contains("b_l_"))
            {
                r_HandDetectionBool = false;
                l_HandDetectionBool = true;
            }
            _pos = pos;
            exerciseStarted = true;
        }
    }

    IEnumerator DisableRealtimePopup()
    {
        yield return new WaitForSeconds(2);
        correctRealtimeInstructions.SetActive(false);
        wrongRealtimeInstructions.SetActive(false);
    }

    public void Release() { StartCoroutine(ReleaseCoroutine()); }

    IEnumerator ReleaseCoroutine()
    {
        if (_timer >= 5 && !handSwitcher)
        {
            bananaSpriteParent.transform.GetChild(_count).gameObject.SetActive(true);
            _count++;
            if (_count == 5)
            {
                _obj.SetActive(false);
                contentHolder.SetActive(false);
                headAnimController.Play("HeadingExit");
                yield return new WaitForSeconds(1.5f);
                exerciseText.text = "Please switch hands";
                yield return new WaitForSeconds(2);
                headAnimController.Play("HeadingIntro");
                yield return new WaitForSeconds(1.5f);
                exerciseText.text = "Knuckle Bend";
                TTSCallFunction(2);
                contentHolder.SetActive(true);
                _wristL.SetActive(false);
                _wristR.SetActive(true);
                handSwitcher = true;
                handText.text = "Right Hand";
                for (int i = 0; i < bananaSpriteParent.transform.childCount; i++)
                {
                    bananaSpriteParent.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
        else if (_timer >= 5 && handSwitcher)
        {
            bananaSpriteParent.transform.GetChild(_count-5).gameObject.SetActive(true);
            _count++;
            if (_count == 10)
            {
                TTSCallFunction(3);
                //_gestureR.SetActive(false);
                _wristR.SetActive(true);
                StartCoroutine(BackToMainScene());
            }
        }
       
        //StopAllCoroutines();
        _obj.SetActive(false);
        _pos = null;
        timerFillingImage.GetComponent<Image>().fillAmount = 0;
        timerIndicator.SetActive(false);
        l_HandDetectionBool = false;
        r_HandDetectionBool = false;
        _timer = 0;
        Debug.Log("hello");
        exerciseStarted = false;
        _cylinder.transform.GetComponent<Renderer>().material = unripedMat;
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

    public void SetUp(bool up)
    {
        Up = up;
    }

    private void FixedUpdate()
    {
        if (_pos != null && _obj.activeInHierarchy)
            _obj.transform.position = _pos.position + new Vector3(0, 0.05f, 0);

        
        if (_timer < 5.2f && exerciseStarted)
        {
            if (l_HandDetectionBool && !r_HandDetectionBool && !handSwitcher)
            {
                _obj.SetActive(true);
                timerIndicator.SetActive(true);
                _timer += 1 * Time.deltaTime;
                timerFillingImage.GetComponent<Image>().fillAmount = _timer / 5.1f;
            }
           
             if (!l_HandDetectionBool && r_HandDetectionBool && handSwitcher)
            {
                _obj.SetActive(true);
                timerIndicator.SetActive(true);
                _timer += 1 * Time.deltaTime;
                timerFillingImage.GetComponent<Image>().fillAmount = _timer / 5.1f;
               
            }
            if (_timer >= 5)
            {
                _cylinder.transform.GetComponent<Renderer>().material = ripedMat;
            }
        }
    }

    public void InstructionsCheck()
    {
        if (l_HandDetectionBool && !r_HandDetectionBool && !handSwitcher)
        {
            correctRealtimeInstructions.SetActive(true);
            wrongRealtimeInstructions.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
        if (l_HandDetectionBool && !r_HandDetectionBool && handSwitcher)
        {
            wrongRealtimeInstructions.SetActive(true);
            correctRealtimeInstructions.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
        if (!l_HandDetectionBool && r_HandDetectionBool && !handSwitcher)
        {
            wrongRealtimeInstructions.SetActive(true);
            correctRealtimeInstructions.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
        if (!l_HandDetectionBool && r_HandDetectionBool && handSwitcher)
        {
            correctRealtimeInstructions.SetActive(true);
            wrongRealtimeInstructions.SetActive(false);
            StartCoroutine(DisableRealtimePopup());
        }
    }
}