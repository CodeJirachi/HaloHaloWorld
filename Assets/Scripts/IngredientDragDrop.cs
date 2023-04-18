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

    public bool inSlot;

    public Vector2 prev_pos;

    public GameObject hoverLabelPrefab;
    GameObject text_label;
    //spoon for halo halo 
    //public GameObject spoon;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        //canvas = GetComponent<Canvas>();
        prev_pos = GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        //Debug.Log("OnBeginDrag");
        Destroy(text_label);
        /*
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
        */
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

       // if halo halo scene, 
            // if spoon active, then allow
        //if (sceneName == "HaloHalo 1")
        //{
        //    if (spoon.activeSelf == true)
        //    {
        //Debug.Log("OnDrag");
        Destroy(text_label);
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        //    }
        //}
        // else, not halo halo scene
        // allow
        //else
        //{
         //   rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
       // }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        Destroy(text_label);
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

    void OnMouseEnter()
    {
        if (inSlot)
        {
            Debug.Log(this.gameObject.name);
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.x += 1;
            mousepos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

            text_label = Instantiate(hoverLabelPrefab, mousepos, Quaternion.identity, canvas.transform);
            text_label.GetComponent<TMPro.TextMeshProUGUI>().text = "<mark=#c0bfde>" + this.gameObject.name + "</mark>"; //for background of text
            text_label.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = this.gameObject.name;
        }
    }

    void OnMouseOver()
    {
        if (inSlot)
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.x += 1;
            mousepos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            //text_label.SetActive(false);

            if (text_label != null)
            {
                text_label.transform.position = mousepos;
            }
            //text_label.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        Destroy(text_label);
    }

}

