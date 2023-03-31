using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EffectsEnabler : MonoBehaviour
{

    [Header("Master Mixer")]
    public AudioMixer mixer;
    public GameObject volumeText;
    public GameObject volumeValue;
    public GameObject volumeSlider;
    public GameObject pitchText;
    public GameObject pitchValue;
    public GameObject pitchSlider;

    [Header("Lowpass effect")]
    public GameObject lowpassButtonOn;
    public GameObject lowpassButtonOff;
    public GameObject lowpassButtonGoBack;
    [Space(6)]
    public GameObject cutoffFreqText;
    public GameObject cutoffValue;
    public GameObject cutoffSlider;
    [Space(6)]
    public GameObject resonanceText;
    public GameObject resonanceValue;
    public GameObject resonanceSlider;

    [Header("SFX Reverb effect")]
    public GameObject sfxReverbButtonOn;
    public GameObject sfxReverbButtonOff;
    public GameObject sfxReverbButtonGoBack;
    [Space(6)]
    public GameObject sfxDecayTimeSlider;
    public GameObject sfxDecayTimeValue;
    public GameObject sfxDecayTimeText;
    [Space(6)]
    public GameObject sfxReverbSlider;
    public GameObject sfxReverbValue;
    public GameObject sfxReverbText;
    [Space(6)]
    public GameObject sfxDiffuseSlider;
    public GameObject sfxDiffuseValue;
    public GameObject sfxDiffuseText;

    [Header("Flange effect")]
    public GameObject flangeButtonOn;
    public GameObject flangeButtonOff;
    public GameObject flangeButtonGoBack;
    [Space(6)]
    public GameObject flangeDepthSlider;
    public GameObject flangeDepthTextValue;
    public GameObject flangeDepthText;
    [Space(6)]
    public GameObject flangeRateSlider;
    public GameObject flangeRateTextValue;
    public GameObject flangeRateText;

    #region Lowpass effect

    /* LowpassON called on button pressed pressed
     * Line1 - set volume of effect to 0 to enable it (0 - enabled, -80 disabled)
     * Line2 - Call method
     * Line3 - Call method
     */
    public void LowpassButtonOn() 
    {
        Debug.Log("Lowpass pressed");
        EnableLowpass();
        DisableVolumeAndPitchObjects();
    }

    /* LowpassOFF called on button pressed pressed
     * Line1 - set volume of effect to -80 to disable it (0 - enabled, -80 disabled)
     * Line2 - Call method
     * Line3 - Call method
     */
    public void LowpassButtonOff()
    {
        mixer.SetFloat("LowpassVolume", -80);
        DisableLowpassSlider();
        EnableVolumeAndPitchObjects();
        Debug.Log("Lowpass disabled pressed");

        // Set button color to default
        lowpassButtonOn.GetComponentInChildren<MeshRenderer>().material.color = Color.black;
    }

    // Make lowpass objects invisible without turning the effect off
    public void LowpassGoBack()
    {
        DisableLowpassSlider();
        EnableVolumeAndPitchObjects();
        Debug.Log("Lowpass go back");
    }

    // Make lowpass slider and text values visible
    private void EnableLowpass()
    {
        // Enable
        mixer.SetFloat("LowpassVolume", 0);
        cutoffSlider.SetActive(true);
        cutoffFreqText.SetActive(true);
        cutoffValue.SetActive(true);

        resonanceText.SetActive(true);
        resonanceSlider.SetActive(true);
        resonanceValue.SetActive(true);

        lowpassButtonOff.SetActive(true);
        lowpassButtonGoBack.SetActive(true);

        // Disable
        lowpassButtonOn.SetActive(false);
        
            //Disable sfx and flange buttons while using lowpass
            sfxReverbButtonOn.SetActive(false);
            flangeButtonOn.SetActive(false);

        // Set button color to red indicating that the effect is on
        lowpassButtonOn.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
    }

    // Make lowpass slider and text values invisible
    private void DisableLowpassSlider()
    {
        // Enable
        lowpassButtonOn.SetActive(true);

        // Make sfx and flange buttons visible again
            sfxReverbButtonOn.SetActive(true);
        flangeButtonOn.SetActive(true);

        // Disable
        cutoffSlider.SetActive(false);
        cutoffFreqText.gameObject.SetActive(false);
        cutoffValue.gameObject.SetActive(false);

        resonanceText.SetActive(false);
        resonanceSlider.SetActive(false);
        resonanceValue.SetActive(false);

        lowpassButtonGoBack.SetActive(false);
        lowpassButtonOff.SetActive(false);
    }

    #endregion

    #region SFX Reverb effect

    /* SFXButtonOn called on button pressed
     * Line1 - set volume of effect to 0 to enable it (0 - enabled, -80 disabled)
     * Line2 - Call method
     * Line3 - Call method
     */
    public void SFXButtonOn()
    {
        Debug.Log("sfx on pressed");
        EnableSFX();
        DisableVolumeAndPitchObjects();
        sfxReverbButtonOn.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
    }

    /* SFXButtonOFF called on button pressed
     * Line1 - set volume of effect to -80 to disable it (0 - enabled, -80 disabled)
     * Line2 - Call method
     * Line3 - Call method
     */
    public void SFXButtonOff()
    {
        mixer.SetFloat("SFXReverbVolume", -80);
        Debug.Log("SFX off pressed");
        DisableSFXObjects();
        EnableVolumeAndPitchObjects();

        sfxReverbButtonOn.GetComponentInChildren<MeshRenderer>().material.color = Color.black;
    }

    // Make sfx objects invisible without turning the effect off
    public void SFXGoBack()
    {
        DisableSFXObjects();
        EnableVolumeAndPitchObjects();
        Debug.Log("sfx go back");
    }

    // Make SFX sliders and text values visible
    private void EnableSFX()
    {
        // Enable
        mixer.SetFloat("SFXReverbVolume", 0);

            // Decay effect
            sfxDecayTimeSlider.SetActive(true);
            sfxDecayTimeValue.gameObject.SetActive(true);
            sfxDecayTimeText.gameObject.SetActive(true);

            // Reverb effect
            sfxReverbSlider.SetActive(true);
            sfxReverbValue.SetActive(true);
            sfxReverbText.SetActive(true);

            // Diffuse effect
            sfxDiffuseSlider.SetActive(true);
            sfxDiffuseValue.SetActive(true);
            sfxDiffuseText.SetActive(true);

        sfxReverbButtonOff.SetActive(true);
        sfxReverbButtonGoBack.SetActive(true);

        // Disable
        sfxReverbButtonOn.SetActive(false);
        flangeButtonOn.SetActive(false);
        
            //Disable lowpass buttons while using lowpass
            lowpassButtonOn.SetActive(false);
    }

    // Make SFX sliders and text values invisible
    private void DisableSFXObjects()
    {
        // Enable 
        sfxReverbButtonOn.SetActive(true);

            // Make lowpass button visible again
            lowpassButtonOn.SetActive(true);
            flangeButtonOn.SetActive(true);

        // Disable
            // Decay effect
            sfxDecayTimeSlider.SetActive(false);
            sfxDecayTimeValue.gameObject.SetActive(false);
            sfxDecayTimeText.gameObject.SetActive(false);

            // Reverb effect
            sfxReverbSlider.SetActive(false);
            sfxReverbValue.SetActive(false);
            sfxReverbText.SetActive(false);

            // Diffuse effect
            sfxDiffuseSlider.SetActive(false);
            sfxDiffuseValue.SetActive(false);
            sfxDiffuseText.SetActive(false);

        sfxReverbButtonOff.SetActive(false);
        sfxReverbButtonGoBack.SetActive(false);
    }

    #endregion

    #region Flange effect

    /* FlangeButtonOn called on button pressed
     * Line1 - set volume of effect to 0 to enable it (0 - enabled, -80 disabled)
     * Line2 - Call method
     * Line3 - Call method
     */
    public void FlangeButtonOn()
    {
        Debug.Log("Flange on pressed");
        EnableFlange();
        DisableVolumeAndPitchObjects();
        flangeButtonOn.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
    }

    /* FlangeButtonOff called on button pressed
     * Line1 - set volume of effect to -80 to disable it (0 - enabled, -80 disabled)
     * Line2 - Call method
     * Line3 - Call method
     */
    public void FlangeButtonOff()
    {
        mixer.SetFloat("FlangeVolume", -80);
        Debug.Log("Flange off pressed");
        DisableFlange();
        EnableVolumeAndPitchObjects();

        flangeButtonOn.GetComponentInChildren<MeshRenderer>().material.color = Color.black;
    }

    // Make sfx objects invisible without turning the effect off
    public void FlangeGoBack()
    {
        DisableFlange();
        EnableVolumeAndPitchObjects();
        Debug.Log("flange go back");
    }

    // Make Flange sliders and text values visible
    private void EnableFlange()
    {
        // Enable
        mixer.SetFloat("FlangeVolume", 0);

        // Rate effect
        flangeRateSlider.SetActive(true);
        flangeRateTextValue.gameObject.SetActive(true);
        flangeRateText.gameObject.SetActive(true);

        // Depth effect
        flangeDepthSlider.SetActive(true);
        flangeDepthTextValue.SetActive(true);
        flangeDepthText.SetActive(true);

        flangeButtonOff.SetActive(true);
        flangeButtonGoBack.SetActive(true);

        // Disable
        flangeButtonOn.SetActive(false);

        //Disable lowpass and sfx buttons while using flange
        lowpassButtonOn.SetActive(false);
        sfxReverbButtonOn.SetActive(false);
    }

    // Make Flange sliders and text values invisible. Enable effect buttons
    private void DisableFlange ()
    {
        // Make sfx button on visible again 
        sfxReverbButtonOn.SetActive(true);

        // Make lowpass button on visible again
        lowpassButtonOn.SetActive(true);

        // Make flange button on visible again
        flangeButtonOn.SetActive(true);

        // Disable
        // Rate effect
        flangeRateSlider.SetActive(false);
        flangeRateTextValue.gameObject.SetActive(false);
        flangeRateText.gameObject.SetActive(false);

        // Depth effect
        flangeDepthSlider.SetActive(false);
        flangeDepthTextValue.SetActive(false);
        flangeDepthText.SetActive(false);

        flangeButtonOff.SetActive(false);
        flangeButtonGoBack.SetActive(false);
    }

    #endregion

    // Disable volume and pitch objects
    private void DisableVolumeAndPitchObjects()
    {
        volumeText.SetActive(false);
        volumeValue.SetActive(false);
        pitchText.SetActive(false);
        pitchValue.SetActive(false);
        volumeSlider.SetActive(false);
        pitchSlider.SetActive(false);
    }

    // Enable volume and pitch objects
    private void EnableVolumeAndPitchObjects()
    {
        volumeText.SetActive(true);
        volumeValue.SetActive(true);
        pitchText.SetActive(true);
        pitchValue.SetActive(true);
        volumeSlider.SetActive(true);
        pitchSlider.SetActive(true);
    }
}