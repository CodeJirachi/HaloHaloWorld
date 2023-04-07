using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public string currentItem;
    IngredientDragDrop ingredient;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            //set new position in slot
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            currentItem = eventData.pointerDrag.GetComponent<RectTransform>().name;
            
            //set inSlot to true
            eventData.pointerDrag.GetComponent<IngredientDragDrop>().inSlot = true;
            
            //set prev pos to slot so it "snaps back" properly
            eventData.pointerDrag.GetComponent<IngredientDragDrop>().prev_pos = GetComponent<RectTransform>().anchoredPosition;

            Debug.Log(currentItem);
        }
    }

}