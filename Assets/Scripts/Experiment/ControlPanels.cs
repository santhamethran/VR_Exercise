using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlPanels : MonoBehaviour
{
    [Header("UserInfo,PainArea,Exercise")]
    public List<GameObject>panels;
    public int previousValue;

    public TMP_Text[] feebback;
 
    public GameObject[] feedBackDropDown;
    public string[] feedBackData;

    private void Start()
    {
        if (SceneControlPanels.instance.IscontrolPanels ==true)
        {
            foreach (GameObject panel in panels)
            {
                panel.SetActive(false);

            }
            panels[2].SetActive(true);
        }
       
       
    }

    public void ChangePanels(int value)
    {

        previousValue = value;
        
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);

        }

        panels[value].SetActive(true);

       
    }
   
}
