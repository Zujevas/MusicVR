using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PitchSlider : MonoBehaviour
{
    public AudioMixer mixer;
    private Text pitchTextValue;
    private int sliderValue;
    private float mixerPitch;


    private void Start()
    {
        pitchTextValue = GameObject.FindGameObjectWithTag("PitchValue").GetComponent<Text>();
    }

    void Update()
    {
        GetPitchSliderValue();
        SetMixerPitch();
    }

    // Get and set slider value as text (0-200) from slider's position
    void GetPitchSliderValue()
    {
        sliderValue = (int)(transform.localPosition.x * 1000);
        sliderValue = sliderValue + 100;
        pitchTextValue.text = sliderValue.ToString();
    }

    void SetMixerPitch()
    {
        mixerPitch = sliderValue / 100f;
        mixer.SetFloat("MixerPitch", mixerPitch);
    }
}
