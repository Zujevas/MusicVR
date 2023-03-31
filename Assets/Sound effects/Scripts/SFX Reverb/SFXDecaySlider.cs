using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFXDecaySlider : MonoBehaviour
{
    public AudioMixer mixer;
    public Text decayTimeValue;
    private float sliderValue;
    private float mixerDecayTime;

    private void Awake()
    {
        //decayTimeValue = GameObject.FindGameObjectWithTag("DecayTimeValue").GetComponent<Text>();
        sliderValue = 0;
        mixerDecayTime = 1;
    }

    void Update()
    {
        GetDecayTimeSliderValue();
        SetDecayTime();
    }

    // Get and set slider value as text (0 to 20) from slider's position
    void GetDecayTimeSliderValue()
    {
        sliderValue = transform.localPosition.x * 100 + 10f;
        decayTimeValue.text = Mathf.Round(sliderValue).ToString();
        Debug.Log(sliderValue);
    }

    void SetDecayTime()
    {
        mixerDecayTime = sliderValue;
        mixer.SetFloat("SFXDecayTime", mixerDecayTime);
    }
}
