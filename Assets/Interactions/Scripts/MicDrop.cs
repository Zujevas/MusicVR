using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MicDrop : MonoBehaviour
{
    public Transform tabble;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Application.Quit();
        }

        if (collision.gameObject.tag == "tabble")
        {
            this.gameObject.transform.SetParent(tabble);
        }
    }


}
