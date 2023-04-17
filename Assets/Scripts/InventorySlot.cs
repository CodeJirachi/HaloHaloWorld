using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public string currentItem;
    GameObject ingredient;

    GameObject ingredient_icon;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            currentItem = eventData.pointerDrag.GetComponent<RectTransform>().name;
            ingredient = eventData.pointerDrag;
            Debug.Log(currentItem);

            //ANOTHER TEMPORARY CONDITIONAL CHECK HERE- gonna generalize this to check tags also maybe
            if(eventData.pointerDrag.GetComponent<RectTransform>().name == "rice cooker")
            {
                GameObject.Find("cooked rice").SetActive(true);
                GameObject.Find("cooked rice").GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                GameObject.Find("cooked rice").GetComponent<IngredientDragDrop>().inSlot = true;
                GameObject.Find("cooked rice").GetComponent<IngredientDragDrop>().prev_pos = GetComponent<RectTransform>().anchoredPosition;
                GameObject.Find("cooked rice").GetComponent<Image>().raycastTarget = true;
            }

            //checking if its a chopped ingredient being dragged in
            else if(currentItem == "chili" || currentItem == "garlic" || currentItem == "green onion")
            {
                ingredient_icon = ingredient.gameObject.GetComponent<FoodDragTrigger>().ingredient_icon;

                ingredient_icon.SetActive(true);
                ingredient_icon.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                ingredient_icon.GetComponent<IngredientDragDrop>().inSlot = true;
                ingredient_icon.GetComponent<IngredientDragDrop>().prev_pos = GetComponent<RectTransform>().anchoredPosition;
                ingredient_icon.GetComponent<Image>().raycastTarget = true;
                ingredient_icon.gameObject.transform.SetParent(this.gameObject.transform.parent.parent, false);
            }

            else if (currentItem == "potFilled")
            //else if (eventData.pointerDrag.GetComponent<RectTransform>().name == "spaghetti pot")
            {
                GameObject.Find("spaghetti pot").SetActive(true);
                GameObject.Find("spaghetti pot").GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                GameObject.Find("spaghetti pot").GetComponent<IngredientDragDrop>().inSlot = true;
                GameObject.Find("spaghetti pot").GetComponent<IngredientDragDrop>().prev_pos = GetComponent<RectTransform>().anchoredPosition;
                GameObject.Find("spaghetti pot").GetComponent<Image>().raycastTarget = true;
            }

            else if (currentItem == "potFilled2")
            {
                GameObject.Find("sauce pot").SetActive(true);
                GameObject.Find("sauce pot").GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                GameObject.Find("sauce pot").GetComponent<IngredientDragDrop>().inSlot = true;
                GameObject.Find("sauce pot").GetComponent<IngredientDragDrop>().prev_pos = GetComponent<RectTransform>().anchoredPosition;
                GameObject.Find("sauce pot").GetComponent<Image>().raycastTarget = true;
            }

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