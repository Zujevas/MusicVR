using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFXReverbSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public Text reverbTextValue;
    private float sliderValue;
    private float mixerReverb;

    // Update is called once per frame
    void Update()
    {
        GetReverbSliderValue();
        SetReverb();
    }

    // Get and set slider value as text (-10000 to 2000) from slider's position
    void GetReverbSliderValue()
    {
        sliderValue = transform.localPosition.x * 60000 - 4000;
        reverbTextValue.text = Mathf.Round(sliderValue).ToString();
        Debug.Log(sliderValue);
    }

    void SetReverb()
    {
        mixerReverb = sliderValue;
        mixer.SetFloat("SFXReverb", mixerReverb);
    }
}
