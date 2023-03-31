using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource audioData;
    public Renderer render;
    private Color originalColor;

    public bool activated;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        activated = false;
        render = GetComponentInChildren<Renderer>();
        originalColor = render.material.color;
    }

    public void PlayAudio()
    {
        audioData.Play();
        activated = !activated;
        if (activated)
        {
            render.material.SetColor("_BaseColor", Color.red);
        }
        else
        {
            render.material.SetColor("_BaseColor", originalColor);
        }
    }
    public void PlayWithoutDeactivating()
    {
        audioData.Play();
    }
}
