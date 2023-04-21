using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverLabelBehavior : MonoBehaviour
{
    public GameObject obj; //the object this label is attached to

    // Update is called once per frame
    void Update()
    {
        this.gameObject.SetActive(obj.activeSelf);
    }
}
