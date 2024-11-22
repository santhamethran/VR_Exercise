using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainAreaHighlight : MonoBehaviour
{
    public GameObject Obj, LeftReticle, RightRetcle;

    public OVRHand leftHand;
    public OVRHand rightHand;

    bool IsPinching(OVRHand hand)
    {
        return hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
    }

    public void OnSurfaceHit()
    {
        if (IsPinching(leftHand))
        {
            Obj.transform.position = LeftReticle.transform.position;
        }
        else if (IsPinching(rightHand))
        {
            Obj.transform.position = RightRetcle.transform.position;
        }
    }
}
