using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBar : MonoBehaviour
{
    BoxCollider box;
    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        box.size = rect.sizeDelta;
    }
}
