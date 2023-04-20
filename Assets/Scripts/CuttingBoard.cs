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

    public GameObject greenChili;
    public GameObject onion;
    public GameObject lechon;

    public GameObject bellPepper;
    public GameObject hotdog;

    public string currentItemName;

    public void OnDrop(PointerEventData eventData)
    {
        currentItem = eventData.pointerDrag;
        currentItemName = currentItem.GetComponent<RectTransform>().name;

        Debug.Log("hi");

        if (currentItemName == "red thai chili" || currentItemName == "red chili icon")
        {
            chili.SetActive(true);
            currentItem.SetActive(false);
        } 
        else if (currentItemName == "garlic icon" || currentItemName == "garlic")
        {
            garlic.SetActive(true);
            currentItem.SetActive(false);
        }
        else if (currentItemName == "green onion")
        {
            greenOnion.SetActive(true);
            currentItem.SetActive(false);
        }

        else if(currentItemName == "green thai chili")
        {
            greenChili.SetActive(true);
            currentItem.SetActive(false);
        }
        else if(currentItemName == "onion")
        {
            onion.SetActive(true);
            currentItem.SetActive(false);
        }
        else if (currentItemName == "crispy pork belly")
        {
            lechon.SetActive(true);
            currentItem.SetActive(false);
        }

        else if (currentItemName == "bell pepper")
        {
            bellPepper.SetActive(true);
            currentItem.SetActive(false);
        }
        else if (currentItemName == "hot dog")
        {
            hotdog.SetActive(true);
            currentItem.SetActive(false);
        }
    
}
}
