using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class DropDownManager : MonoBehaviour
{
    public TMP_Text DropdownBtn;
    public GameObject feedBackDropDownBtn;
    public GameObject feedBackBtn;

    public void DropDownClick(string value)
    {
        DropdownBtn.text =value;
        feedBackDropDownBtn.SetActive(false);
        feedBackBtn.SetActive(true);
    }
   
    public void feebackClicked()
    {
        feedBackBtn.SetActive(false);
        feedBackDropDownBtn.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        feedBackBtn.SetActive(true);
        feedBackDropDownBtn.gameObject.SetActive(false);
    }


    //public GameObject panel;

    //private bool panelActive = false;

    //void Start()
    //{

    //    panel.SetActive(panelActive);

    //}

    //void Update()
    //{
    //    // Check if the panel is active and if a click occurred outside the panel
    //    if ( Input.GetMouseButtonDown(0))
    //    {
    //        // Check if the click was not on the button or panel
    //        if ( IsPointerOverUIElement(panel))
    //        {
    //            feedBackBtn.SetActive(true);
    //            panel.SetActive(false);
    //            panelActive = false;
    //        }
    //    }
    //}



    //private bool IsPointerOverUIElement(GameObject uiElement)
    //{
    //    PointerEventData eventData = new PointerEventData(EventSystem.current);
    //    eventData.position = Input.mousePosition;
    //    eventData.pressPosition = Input.mousePosition;

    //    GraphicRaycaster raycaster = uiElement.GetComponentInParent<GraphicRaycaster>();
    //    if (raycaster != null)
    //    {
    //        System.Collections.Generic.List<RaycastResult> results = new System.Collections.Generic.List<RaycastResult>();
    //        raycaster.Raycast(eventData, results);
    //        return results.Count > 0;
    //    }
    //    return false;
    //}

}
