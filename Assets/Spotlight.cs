using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float maxSpeed;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        anim.SetFloat("Speed", Random.Range(minSpeed, maxSpeed));
    }
}
