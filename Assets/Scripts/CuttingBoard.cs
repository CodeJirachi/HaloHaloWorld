using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CuttingBoard : MonoBehaviour, IDropHandler
{
    GameObject currentItem;
    IngredientDragDrop ingredient;

    //TEMPORARY SOLUTION - how to get the game object without having to put it in inspector? maybe make it active off screen and change its position?
    public GameObject chili;
    public GameObject garlic;
    public string currentItemName;

    public void OnDrop(PointerEventData eventData)
    {
        currentItem = eventData.pointerDrag;
        currentItemName = currentItem.GetComponent<RectTransform>().name;

        if (currentItemName == "red chili icon")
        {
            chili.SetActive(true);
            currentItem.SetActive(false);
        } else if (currentItemName == "garlic icon")
        {
            garlic.SetActive(true);
            currentItem.SetActive(false);
        }
    }
}
