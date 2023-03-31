using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Row : MonoBehaviour
{
    public List<Audio> cubes;

    public void PlayRow()
    {
        foreach (Audio c in cubes)
        {
            if (c.activated)
            {
                StartCoroutine(ColorSwitch(c));
            }
        }
    }

    IEnumerator ColorSwitch(Audio c)
    {
        c.render.material.SetColor("_BaseColor", Color.blue);
        c.PlayWithoutDeactivating();
        yield return new WaitForSeconds(0.15f);
        c.render.material.SetColor("_BaseColor", Color.red);
    }


}
