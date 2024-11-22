using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOff : MonoBehaviour
{
    public GameObject ObjectToggle;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("TurnPanelOff", 5);
        
    }

    // Update is called once per frame
    public void TurnPanelOff()
    {
        ObjectToggle.SetActive(false);
    }

    public void TurnPanelOn()
    {
        ObjectToggle.SetActive(true);
    }
}