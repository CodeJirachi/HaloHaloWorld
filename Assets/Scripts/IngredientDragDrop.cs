using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class IngredientDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //with help from https://www.youtube.com/watch?v=BGr-7GZJNXg

    public RectTransform rectTransform;
    public CanvasGroup canvasGroup;
    public Canvas canvas;

    public static IngredientDragDrop ING;
    public bool inSlot;

    public Vector2 prev_pos;

    //spoon for halo halo 
    public GameObject spoon;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        //canvas = GetComponent<Canvas>();
        prev_pos = GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

       // if halo halo scene, 
            // if spoon active, then allow
        if (sceneName == "HaloHalo 1")
        {
            if (spoon.activeSelf == true)
            {
            Debug.Log("OnBeginDrag IngredientDragDrop");
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
            }
        }
        // else, not halo halo scene
        // allow
        else {
        Debug.Log("OnBeginDrag IngredientDragDrop");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

       // if halo halo scene, 
            // if spoon active, then allow
        if (sceneName == "HaloHalo 1")
        {
            if (spoon.activeSelf == true)
            {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
        }
        // else, not halo halo scene
        // allow
        else
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        //rectTransform.localScale = new Vector2(0, 0);

        //rectTransform.anchoredPosition -= eventData.delta;
        //rectTransform.anchoredPosition = new Vector2(-60, -90);
        if (inSlot)
        {
            rectTransform.anchoredPosition = prev_pos;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
        
    }

}

