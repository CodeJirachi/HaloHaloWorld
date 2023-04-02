using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngredientDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //with help from https://www.youtube.com/watch?v=BGr-7GZJNXg

    public RectTransform rectTransform;
    public CanvasGroup canvasGroup;
    public Canvas canvas;

    protected Vector2 prev_pos;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        prev_pos = GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        //rectTransform.localScale = new Vector2(0, 0);

        //rectTransform.anchoredPosition -= eventData.delta;
        //rectTransform.anchoredPosition = new Vector2(-60, -90);
        rectTransform.anchoredPosition = prev_pos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
        
    }

}

