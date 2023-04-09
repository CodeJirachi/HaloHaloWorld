using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public string currentItem;
    IngredientDragDrop ingredient;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            currentItem = eventData.pointerDrag.GetComponent<RectTransform>().name;
            Debug.Log(currentItem);
            //ANOTHER TEMPORARY CONDITIONAL CHECK HERE - check if its a fake - gonna generalize this to check tags also maybe
            if(eventData.pointerDrag.GetComponent<RectTransform>().name == "rice cooker")
            {
                GameObject.Find("cooked rice").SetActive(true);
                GameObject.Find("cooked rice").GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                GameObject.Find("cooked rice").GetComponent<IngredientDragDrop>().inSlot = true;
                GameObject.Find("cooked rice").GetComponent<IngredientDragDrop>().prev_pos = GetComponent<RectTransform>().anchoredPosition;
                GameObject.Find("cooked rice").GetComponent<Image>().raycastTarget = true;
            }

            else if(currentItem == "chili")
            {
                GameObject.Find("chili icon").SetActive(true);
                GameObject.Find("chili icon").GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                GameObject.Find("chili icon").GetComponent<IngredientDragDrop>().inSlot = true;
                GameObject.Find("chili icon").GetComponent<IngredientDragDrop>().prev_pos = GetComponent<RectTransform>().anchoredPosition;
                GameObject.Find("chili icon").GetComponent<Image>().raycastTarget = true;
            }

            //TEMPORARY IF - gonna change this to check tags maybe?
            else
            {
                //set new position in slot
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                //set inSlot to true
                eventData.pointerDrag.GetComponent<IngredientDragDrop>().inSlot = true;

                //set prev pos to slot so it "snaps back" properly
                eventData.pointerDrag.GetComponent<IngredientDragDrop>().prev_pos = GetComponent<RectTransform>().anchoredPosition;

                //Debug.Log(currentItem);
            }
        }
    }

}