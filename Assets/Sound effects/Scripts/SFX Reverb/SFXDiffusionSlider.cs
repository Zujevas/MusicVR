using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFXDiffusionSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public Text diffusionTextValue;
    private float sliderValue;
    private float mixerDiffusion;

    // Update is called once per frame
    void Update()
    {
        GetDiffusionSliderValue();
        SetDiffusion();
    }

    // Get and set slider value as text (0% to 100%) from slider's position
    void GetDiffusionSliderValue()
    {
        sliderValue = transform.localPosition.x * 500 + 50;
        diffusionTextValue.text = Mathf.Round(sliderValue).ToString();
        Debug.Log(sliderValue);
    }

    void SetDiffusion()
    {
        mixerDiffusion = sliderValue;
        mixer.SetFloat("SFXDiffusion", mixerDiffusion);
    }
}
