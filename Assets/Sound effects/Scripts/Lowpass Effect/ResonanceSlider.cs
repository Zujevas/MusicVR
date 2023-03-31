using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ResonanceSlider : MonoBehaviour
{

    public AudioMixer mixer;
    public Text resonanceTextValue;
    private int resonanceSliderValue;
    private int mixerResonance;

    void Update()
    {
        GetResonanceSliderValue();
        SetResonance();
    }

    // Get and set resonance slider value as text (0-10) from slider's position
    void GetResonanceSliderValue()
    {
        resonanceSliderValue = (int)((transform.localPosition.x * 50) + 5);
        resonanceTextValue.text = resonanceSliderValue.ToString();
    }

    void SetResonance()
    {
        mixerResonance = resonanceSliderValue;
        mixer.SetFloat("LowpassResonance", mixerResonance);
    }
}
