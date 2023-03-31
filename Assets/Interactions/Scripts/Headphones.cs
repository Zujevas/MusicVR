using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class Headphones : MonoBehaviour
{

    public SteamVR_Action_Boolean steamVR;
    public Transform tabble;
    
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Head" && (steamVR.GetStateUp(SteamVR_Input_Sources.LeftHand) || (steamVR.GetStateUp(SteamVR_Input_Sources.RightHand))))
       {
        print("new scene");
       SceneManager.LoadScene("MainGameScene");
            this.gameObject.SetActive(false);
       }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "tabble")
        {
            this.gameObject.transform.SetParent(tabble);
        }
    }
}
