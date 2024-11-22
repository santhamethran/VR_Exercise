using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOn : MonoBehaviour
{
    //public GameObject IntroPanel, InstructionPanel, LogoPanel;
    public GameObject LogoPanel, InstructionPanel, settingsPanel;
    bool IsControlSettings;

    void Start()
    {
        StartCoroutine(InstantiatePanels());
    }

    IEnumerator InstantiatePanels()
    {
        yield return new WaitForSeconds(5f);
        LogoPanel.SetActive(false);
        InstructionPanel.SetActive(true);
    }
    public void ControlSettingsPanel()
    {
        IsControlSettings = !IsControlSettings;
        settingsPanel.SetActive(IsControlSettings);
    }

    /*-------------Old Script------------------*/
    //IEnumerator InstantiatePanels()
    //{
    //    yield return new WaitForSeconds(11);
    //    IntroPanel.SetActive(false);
    //    InstructionPanel.SetActive(true);
    //    yield return new WaitForSeconds(5);
    //    InstructionPanel.SetActive(false);
    //    LogoPanel.SetActive(true);
    //}
}