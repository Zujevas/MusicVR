using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.Extras;

public class LaserInput : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;



    private void Start()
    {
        laserPointer = GameObject.Find("RightHand").GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerClick += PointerClick;

    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.CompareTag("Instrument"))
        {
            Debug.Log("Cube was clicked");
        }


    }

}
