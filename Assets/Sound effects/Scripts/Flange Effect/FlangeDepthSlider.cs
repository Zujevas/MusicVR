using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class FlangeDepthSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public Text flangeDepthTextValue;
    private float flangeDepthSliderValue;
    private float mixerDepth;

    void Update()
    {
        GetDepth();
        SetCutoffFreq();
    }

    // Get and set depth slider value as text (0 to 1) from slider's position
    void GetDepth()
    {
        flangeDepthSliderValue = Mathf.Round((float)((transform.localPosition.x * 5 + .501) * 100)) / 100;
        flangeDepthTextValue.text = flangeDepthSliderValue.ToString();
    }

    void SetCutoffFreq()
    {
        mixerDepth = flangeDepthSliderValue;
        mixer.SetFloat("FlangeDepth", mixerDepth);
    }


}
