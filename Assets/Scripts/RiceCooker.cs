using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RiceCooker : MonoBehaviour, IDropHandler
{

    public string currentItem;
    public GameObject redlight;
    public GameObject orangelight;
    public GameObject cookedRice;

    GameObject currentIngredient;
    Vector2 currentPrevPosition;

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            currentIngredient = eventData.pointerDrag;
            currentItem = currentIngredient.GetComponent<RectTransform>().name;
            currentPrevPosition = currentIngredient.GetComponent<IngredientDragDrop>().prev_pos;

            if (currentItem == "raw rice")
            {
                currentIngredient.SetActive(false);
                cookedRice.GetComponent<RectTransform>().anchoredPosition = currentPrevPosition;
                cookedRice.SetActive(true);
            }

            Debug.Log(currentItem);
        }
    }
}
