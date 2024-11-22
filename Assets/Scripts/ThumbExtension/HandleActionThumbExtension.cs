using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandleActionThumbExtension : MonoBehaviour
{
    public TextMeshProUGUI _scoreL;
    public RotatingThumbExtension _rot;
    public ThumbExtensionExerciseHandler _teh;

    private void OnTriggerStay(Collider other)
    {
        if (_rot.rightTouchable && other.name.Contains("Thumb")) 
        {
            _rot.rightTouchable = false;
            _teh.RightHandScore();
        }
        else if (_rot.leftTouchable && other.name.Contains("Thumb"))
        {
            _rot.leftTouchable = false;
            _teh.LeftHandScore();
        }
        _rot.StopRotating();
        //this.gameObject.GetComponent<Renderer>().material.color = Color.green;
        if (gameObject.name == "mango") { this.gameObject.GetComponent<Renderer>().material = _teh.fruitsMat[1]; }
        else if (gameObject.name == "avocado") { this.gameObject.GetComponent<Renderer>().material = _teh.fruitsMat[3]; }
        else if (gameObject.name == "fig") { this.gameObject.GetComponent<Renderer>().material = _teh.fruitsMat[5]; }
        else if (gameObject.name == "orange") { this.gameObject.GetComponent<Renderer>().material = _teh.fruitsMat[7]; }
    }

    private void OnTriggerExit(Collider other)
    {
        KeepGoing();
    }

    public void KeepGoing()
    {
        //gameObject.GetComponent<Renderer>().material.color = Color.red;
        if (gameObject.name == "mango") { this.gameObject.GetComponent<Renderer>().material = _teh.fruitsMat[0]; }
        else if (gameObject.name == "avocado") { this.gameObject.GetComponent<Renderer>().material = _teh.fruitsMat[2]; }
        else if (gameObject.name == "fig") { this.gameObject.GetComponent<Renderer>().material = _teh.fruitsMat[4]; }
        else if (gameObject.name == "orange") { this.gameObject.GetComponent<Renderer>().material = _teh.fruitsMat[6]; }
        _rot.KeepRotating();
        // _rot.touchable = false;
    }
}
