using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sink : MonoBehaviour, IDropHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    // detects empty pot, that WILL be filled 
    public string currentItem;

    // sink fills the pot w water
    // this is the filled pot that drags away back into inventory for usage 
    public GameObject filledPot;

    public GameObject filledCollander;

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

            if (currentItem == "empty pot")
            {
                currentIngredient.SetActive(false);
                StartCoroutine(FillPot(1.0f));
                //cookedRice.GetComponent<RectTransform>().anchoredPosition = currentPrevPosition;
                //cookedRice.SetActive(true);

            }
            else if (currentItem == "collanderParent")
            {
                //currentIngredient.SetActive(false);

                //if (currentItem == "potFilled")
                //{
                    currentIngredient.SetActive(false);
                    StartCoroutine(SinkCollander(0.0f));


                //}
                //need another function for filling collander maybe??
            }

            //else if (currentItem == "potFilled")
            //else if (currentIngredient == "potFilled")
            //{
            //    currentIngredient.SetActive(false);
            //    StartCoroutine(FillCollander(0.0f));
            //}

            Debug.Log(currentItem);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!filledPot.GetComponent<IngredientDragDrop>().inSlot)
        {
            Debug.Log("begindrag");

            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

            filledPot.SetActive(true);
            filledPot.GetComponent<IngredientDragDrop>().inSlot = false;
            filledPot.GetComponent<RectTransform>().position = mousepos;
            filledPot.GetComponent<Image>().raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!filledPot.GetComponent<IngredientDragDrop>().inSlot)
        {
            filledPot.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //if (orangelight.activeSelf)
        //{
        if (!filledPot.GetComponent<IngredientDragDrop>().inSlot)
            {
                filledPot.SetActive(true);
                //cookedRice.SetActive(false);
            }
        //}
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public IEnumerator FillPot(float seconds)
    {
      
        //yield return new WaitForSeconds(seconds);
        int stage = 0;
        int stageMax = 5;

        filledPot.SetActive(true);

        while (currentItem == "empty pot" && stage <= stageMax)
        {
            yield return new WaitForSeconds(seconds);
            filledPot.transform.GetChild(stage).gameObject.SetActive(true);
            stage++;
        } 
        
    }

    public IEnumerator SinkCollander(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        filledCollander.SetActive(true);
    }

    // this does not work 
    //public IEnumerator FillCollander(float seconds)
    //{
    //   yield return new WaitForSeconds(seconds);
        //fills with pasta 
    //    filledCollander.transform.GetChild(1).gameObject.SetActive(true);
    //}
}
