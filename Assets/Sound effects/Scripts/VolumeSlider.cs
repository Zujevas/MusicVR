using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;
    private Text volumeTextValue;
    private int sliderValue;
    private int mixerVolume;

    private void Start()
    {
        volumeTextValue = GameObject.FindGameObjectWithTag("VolumeValue").GetComponent<Text>();
    }

    void Update()
    {
        GetVolumeSliderValue();
        SetMixerVolume();
    }

    // Get and set slider value as text (-80 to 0) from slider's position
    void GetVolumeSliderValue()
    {
        sliderValue = (int)(transform.localPosition.x * 400);
        sliderValue -= 40;
        volumeTextValue.text = (sliderValue + 80).ToString();
    }

    void SetMixerVolume()
    {
        mixerVolume = sliderValue;
        mixer.SetFloat("MixerVolume", mixerVolume);
    }
}
