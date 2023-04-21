using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RiceCooker : MonoBehaviour, IDropHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public string currentItem;
    public GameObject redlight;
    public GameObject orangelight;
    public GameObject cookedRice;
    public Canvas canvas;

    public GameObject achievementPrefab;

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
                StartCoroutine(CookRice(5.0f));
                Instantiate(achievementPrefab);
                //cookedRice.GetComponent<RectTransform>().anchoredPosition = currentPrevPosition;
                //cookedRice.SetActive(true);
            }

            Debug.Log(currentItem);
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (orangelight.activeSelf && !cookedRice.GetComponent<IngredientDragDrop>().inSlot)
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
        if (orangelight.activeSelf && !cookedRice.GetComponent<IngredientDragDrop>().inSlot)
        {
            cookedRice.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (orangelight.activeSelf)
        {
            if (!cookedRice.GetComponent<IngredientDragDrop>().inSlot)
            {
                cookedRice.SetActive(false);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    private IEnumerator CookRice(float seconds)
    {
        redlight.SetActive(true);

        yield return new WaitForSeconds(seconds);


        redlight.SetActive(false);
        orangelight.SetActive(true);
    }

}
