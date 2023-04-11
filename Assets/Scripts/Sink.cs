using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sink : MonoBehaviour, IDropHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public string currentItem;
    public GameObject cookedRice;
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
                StartCoroutine(CookRice(1.5f));
                //cookedRice.GetComponent<RectTransform>().anchoredPosition = currentPrevPosition;
                //cookedRice.SetActive(true);
            }

            Debug.Log(currentItem);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!cookedRice.GetComponent<IngredientDragDrop>().inSlot)
        {
            Debug.Log("begindrag");

            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

            cookedRice.SetActive(true);
            cookedRice.GetComponent<IngredientDragDrop>().inSlot = false;
            cookedRice.GetComponent<RectTransform>().position = mousepos;
            cookedRice.GetComponent<Image>().raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!cookedRice.GetComponent<IngredientDragDrop>().inSlot)
        {
            cookedRice.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //if (orangelight.activeSelf)
        //{
            if (!cookedRice.GetComponent<IngredientDragDrop>().inSlot)
            {
                cookedRice.SetActive(true);
                //cookedRice.SetActive(false);
            }
        //}
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public IEnumerator CookRice(float seconds)
    {
        //redlight.SetActive(true);
        
        
        //yield return new WaitForSeconds(seconds);
        int stage = 0;
        int stageMax = 5;

        cookedRice.SetActive(true);

        while (currentItem == "empty pot" && stage <= stageMax)
        {
            yield return new WaitForSeconds(seconds);
            cookedRice.transform.GetChild(stage).gameObject.SetActive(true);
            //rawRice.SetActive(false);
            //currIngredientLayer++;
            stage++;
        } 


        //cookedRice.SetActive(true);
        //cookedRice.transform.GetChild(2).gameObject.SetActive(true);
        
        //cookedRice.transform.GetChild(stage).gameObject.SetActive(false);
        //stage++;
        //cookedRice.transform.GetChild(stage).gameObject.SetActive(true);

        //redlight.SetActive(false);
        //orangelight.SetActive(true);
        
    }
}
