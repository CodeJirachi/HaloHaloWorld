using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodContainer : MonoBehaviour, IDropHandler
{
    SerializeField GameObject 

    public string currentIngredient;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            currentIngredient = eventData.pointerDrag.GetComponent<RectTransform>().name;
            if currentIngredient= 
            Debug.Log(currentIngredient);
        }
    }

}
