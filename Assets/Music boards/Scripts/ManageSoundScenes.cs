using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;

public class ManageSoundScenes : MonoBehaviour
{
    [SerializeField]
    private SteamVR_LaserPointer laserPointer;

    [SerializeField]
    private GameObject addScenePrefab;
    // Start is called before the first frame update
    private void Start()
    {
        laserPointer = GameObject.Find("RightHand").GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerClick += PointerClick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.CompareTag("Plus"))
        {
           AddScene();
        }
    }
    public void AddScene()
    {
        Debug.Log("lll");
        var amount = GameObject.Find("ListContent").transform.childCount;

        GameObject go = Instantiate(addScenePrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        go.transform.SetParent(GameObject.Find("ListContent").transform, false);
        go.transform.SetSiblingIndex(amount - 1);

        var a = GameObject.Find("Scrollbar").GetComponent<Scrollbar>();

        a.value = 1f;
        Debug.Log(a);

        Debug.Log("aaa");
    }
}
