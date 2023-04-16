using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{

    public RectTransform rectTransform;
    public CanvasGroup canvasGroup;
    public Canvas canvas;

    void Start()
    {
        //rectTransform = GetComponent<RectTransform>();
        //canvasGroup = GetComponent<CanvasGroup>();
        //canvas = GetComponent<Canvas>();
    }

    void Update()
    {
        //from https://gamedevbeginner.com/make-an-object-follow-the-mouse-in-unity-in-2d/
        //rectTransform.anchoredPosition = Input.mousePosition / canvas.scaleFactor;
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (this.gameObject.name == "spoon") //spoon sprite offset
        {
            mousepos.x += 0.8f;
            mousepos.y += 1.5f;
        }

        mousepos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousepos;
    }
}
