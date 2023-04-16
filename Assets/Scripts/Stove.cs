using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Stove : MonoBehaviour, IDropHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public string currentItem;
    // change naming conventions later, the stove script just makes the stove appear when the filled pot is dragged onto the stove 
    // ... for now 
    public GameObject pot;
    public GameObject pot2;
    public GameObject pan;
    //public GameObject cookedSpaghetti;
    public Canvas canvas;

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

            if (currentItem == "filled pot")
            {
                currentIngredient.SetActive(false);
                pot.SetActive(true);
                Debug.Log(currentIngredient);

                //StartCoroutine(CookRice(0f));
                //cookedRice.GetComponent<RectTransform>().anchoredPosition = currentPrevPosition;
                //cookedRice.SetActive(true);
            }
            else if (currentItem == "empty pot 2")
            {
                currentIngredient.SetActive(false);
                pot2.SetActive(true);
            }

            else if (currentItem == "empty pan")
            {
                currentIngredient.SetActive(false);
                pan.SetActive(true);
            }

            Debug.Log(currentItem);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!pot.GetComponent<IngredientDragDrop>().inSlot)
        {
            Debug.Log("begindrag");

            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

            pot.SetActive(true);
            pot.GetComponent<IngredientDragDrop>().inSlot = false;
            pot.GetComponent<RectTransform>().position = mousepos;
            pot.GetComponent<Image>().raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!pot.GetComponent<IngredientDragDrop>().inSlot)
        {
            pot.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //if (orangelight.activeSelf)
        //{
        if (!pot.GetComponent<IngredientDragDrop>().inSlot)
        {
            pot.SetActive(true);
            //cookedRice.SetActive(false);
        }
        //}
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    /*
    public IEnumerator CookRice(float seconds)
    {

        //yield return new WaitForSeconds(seconds);
        //int stage = 0;
        //int stageMax = 5;
        yield return new WaitForSeconds(seconds);
        cookedRice.SetActive(true);

        Debug.Log(currentIngredient);

        //while (currentItem == "filled pot" && stage <= stageMax)
        //{
        //   yield return new WaitForSeconds(seconds);
        //    cookedRice.transform.GetChild(stage).gameObject.SetActive(true);
        //    stage++;
        //}

    }
     */
}

