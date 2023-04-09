using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CuttingBoard : MonoBehaviour, IDropHandler
{
    GameObject currentItem;
    IngredientDragDrop ingredient;

    public GameObject chili;
    public string currentItemName;

    public void OnDrop(PointerEventData eventData)
    {
        currentItem = eventData.pointerDrag;
        currentItemName = currentItem.GetComponent<RectTransform>().name;

        if (currentItemName == "red chili icon")
        {
            chili.SetActive(true);
            currentItem.SetActive(false);
        }
    }
}
