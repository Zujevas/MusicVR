using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class CutoffFreqSlider : MonoBehaviour
{
    public AudioMixer mixer;
    private Text cutoffFreqTextValue;
    private int cutoffSliderValue;
    private int mixerCutoffFreq;


    private void Start()
    {
        cutoffFreqTextValue = GameObject.FindGameObjectWithTag("CutoffFreqValue").GetComponent<Text>();
    }

    void Update()
    {
        GetCutoffFreqSliderValue();
        SetCutoffFreq();
    }

    // Get and set cutoffFreq slider value as text (10 to 20010) from slider's position
    void GetCutoffFreqSliderValue()
    {
        cutoffSliderValue = (int)((transform.localPosition.x * 100000) + 10010);
        cutoffFreqTextValue.text = cutoffSliderValue.ToString();
    }

    void SetCutoffFreq()
    {
        mixerCutoffFreq = cutoffSliderValue;
        mixer.SetFloat("LowpassCutoffFreq", mixerCutoffFreq);
    }


}
