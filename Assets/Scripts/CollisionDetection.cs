using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] GameObject Hand;

    bool catchable = false;

    public void PoseCheck(bool check)
    {
        catchable = check;
    }

    public void CorrectPose(){
        catchable = true;
    }

    public void NoPose(){
        catchable = false;
    }

    void OnCollisionEnter(Collision col){
        //SendMessageUpwards("ScoreDebug");
        if (catchable && col.gameObject == Hand)
        {
            transform.position = transform.parent.position;
            gameObject.SetActive(false);
            SendMessageUpwards(Hand.tag == "Left" ? "LeftScore" : "RightScore");
        }
    }
}
