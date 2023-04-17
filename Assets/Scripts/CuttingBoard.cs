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
    public GameObject greenOnion;
    public string currentItemName;

    public void OnDrop(PointerEventData eventData)
    {
        currentItem = eventData.pointerDrag;
        currentItemName = currentItem.GetComponent<RectTransform>().name;

        Debug.Log("hi");

        if (currentItemName == "red thai chili")
        {
            chili.SetActive(true);
            currentItem.SetActive(false);
        } else if (currentItemName == "garlic")
        {
            garlic.SetActive(true);
            currentItem.SetActive(false);
        }
        else if (currentItemName == "green onion")
        {
            greenOnion.SetActive(true);
            currentItem.SetActive(false);
        }
    }
}
