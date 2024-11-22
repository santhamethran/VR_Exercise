using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjects : MonoBehaviour
{

    [SerializeField] List<GameObject> Objects = new List<GameObject>();

    float wait = 3f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(13);
        StartCoroutine(WaitAndActivate(wait));
    }

    IEnumerator WaitAndActivate(float waitTime){
        Restart:
        foreach(GameObject _object in Objects){
             _object.SetActive(true);
            BroadcastMessage("StartTime");
            BroadcastMessage("CheckLongitivity");
            yield return new WaitForSeconds(waitTime);
        }
        goto Restart;

    }
}


