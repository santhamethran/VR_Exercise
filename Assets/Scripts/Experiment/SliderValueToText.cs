using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SliderValueToText : MonoBehaviour
{
   
   

    
    public void OnPainScaleSliderValueChanged()
    {
        PainScale();
    }
    public void OnProgressScaleSliderValueChanged()
    {
        ProgressScaleValue();
    }

    private void PainScale()
    {
        float sliderValue = GetComponent<Slider>().value;

        if (sliderValue >= 0 && sliderValue <= 4f)
        {
            GetComponentInChildren<TMP_Text>().text = "Low";
        }
        else if (sliderValue > 4f && sliderValue <= 6f)
        {
            GetComponentInChildren<TMP_Text>().text = "Same";
        }
        else if (sliderValue > 6f && sliderValue <= 10f)
        {
            GetComponentInChildren<TMP_Text>().text = "High";
        }
    }
    private void ProgressScaleValue()
    {
        float sliderValue = GetComponent<Slider>().value;

        if (sliderValue >= 0 && sliderValue <= 4f)
        {
            GetComponentInChildren<TMP_Text>().text = "Better Yesterday";
        }
        else if (sliderValue > 4f && sliderValue <= 6f)
        {
           GetComponentInChildren<TMP_Text>().text = "No Changes";
        }
        else if (sliderValue > 6f && sliderValue <= 10f)
        {
            GetComponentInChildren<TMP_Text>().text = "Better Today";
        }
    }
}
