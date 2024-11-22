using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeactivateSpheres : MonoBehaviour
{
    float timer = 0f;
    float deactivation = 7f;
    bool startCount = false;
    bool noGround = true;

    //Debugging
    //public TMP_Text timerText;

    private void OnEnable()
    {
        StartCoroutine(WaitDeactivate(5.0f));
    }

    private void LateUpdate(){
        if(startCount){
            timer += Time.deltaTime;
            //See on canvas
            /*if(gameObject.tag != "Ignore"){
                timerText.text = timer.ToString();
            }*/
        }
    }

    public void CheckLongitivity(){
        if(timer >= deactivation){
            startCount = false;
            timer = 0f;
            StartCoroutine(WaitDeactivate(2.0f));
        }
    }

    public void StartTime(){
        if(gameObject.activeSelf && noGround){
            startCount = true;
            noGround = false;
        }
    }

    IEnumerator WaitDeactivate (float waitTime){
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
        gameObject.transform.position = transform.parent.position;
        noGround = true;
    }
}
