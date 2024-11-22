using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuOn : MonoBehaviour
{
    public GameObject MenuPanel;

    public void TurnPanelOn()
    {
        SceneManager.LoadScene("_Main", LoadSceneMode.Single);
    }
}