using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAnimationStart : MonoBehaviour
{
    public Animator anim;
    public float time = 1f;
    public float maxSpeed = 0f;
    public float minSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //anim.GetComponent<Animator>();
        StartCoroutine(Timer(GenerateRandomNumber(0f, time)));
        
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        anim.SetBool("Start", true);
        if (maxSpeed != 0f)
            anim.SetFloat("Speed", GenerateRandomNumber(minSpeed, maxSpeed));
    }

    private float GenerateRandomNumber(float minValue, float maxValue)
    {
        float number;
        number = Random.Range(minValue, maxValue);

        return number;
    }
}
