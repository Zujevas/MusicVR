using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class FlangeRateSlider : MonoBehaviour
{

    public AudioMixer mixer;
    public Text flangeRateTextValue;
    private float rateSliderValue;
    private float mixerFlangeRate;

    void Update()
    {
        GetRateSliderValue();
        SetRate();
    }

    // Get and set resonance slider value as text (0-10) from slider's position
    void GetRateSliderValue()
    {
        rateSliderValue = Mathf.Round((float)(((transform.localPosition.x * 100) + 10.001f) * 100)) /100;
        flangeRateTextValue.text = rateSliderValue.ToString();
    }

    void SetRate()
    {
        mixerFlangeRate = rateSliderValue;
        mixer.SetFloat("FlangeRate", mixerFlangeRate);
    }
}
