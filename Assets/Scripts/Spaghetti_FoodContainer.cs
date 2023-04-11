using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Spaghetti_FoodContainer : MonoBehaviour, IDropHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public string currentItem;
    // game objects for ingredients that goes into pot
    [SerializeField] GameObject potEmpty;
    [SerializeField] GameObject rawSpaghetti;
    [SerializeField] GameObject underwaterSpaghetti;

    //pot not done 
    public GameObject redlight;
    //indicates pot done boiling 
    public GameObject greenlight;

    public Canvas canvas;
  
    // game objects for ingredients that goes into pan
    //[SerializeField] GameObject dfgfdgfdgfd;

    // OG state of pot and pan on stovetop 
    public GameObject potCooking;
    public GameObject panCooking;

    public string currentIngredient;
    GameObject draggedObject;

    Vector2 currentPrevPosition;

    private int currIngredientLayer;

    public void Awake()
    {
        currIngredientLayer = 0;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            draggedObject = eventData.pointerDrag;
            currentIngredient = draggedObject.name;
            //currentIngredient = draggedObject.name;
            //currentItem = currentIngredient.GetComponent<RectTransform>().name;
            //currentPrevPosition = currentIngredient.GetComponent<IngredientDragDrop>().prev_pos;

            // raw spaghetti
            if (currentIngredient == "raw spaghetti" && currIngredientLayer == 0)
            {
                potCooking.transform.GetChild(5).gameObject.SetActive(true);
                StartCoroutine(CookSpaghetti(5.0f));
                draggedObject.SetActive(false);
                //currentIngredient.SetActive(false);

                //after a few secconds, make the spaghetti submerge 

                currIngredientLayer++;
            }
            else
            {
                Debug.Log(currentIngredient);
            }

        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (greenlight.activeSelf && !underwaterSpaghetti.GetComponent<IngredientDragDrop>().inSlot)
        {
            Debug.Log("begindrag");

            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

            underwaterSpaghetti.SetActive(true);
            underwaterSpaghetti.GetComponent<IngredientDragDrop>().inSlot = false;
            underwaterSpaghetti.GetComponent<RectTransform>().position = mousepos;
            underwaterSpaghetti.GetComponent<Image>().raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (greenlight.activeSelf && !underwaterSpaghetti.GetComponent<IngredientDragDrop>().inSlot)
        {
            underwaterSpaghetti.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (greenlight.activeSelf)
        {
            if (!underwaterSpaghetti.GetComponent<IngredientDragDrop>().inSlot)
            {
                underwaterSpaghetti.SetActive(false);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    private IEnumerator CookSpaghetti(float seconds)
    {
        redlight.SetActive(true);

        yield return new WaitForSeconds(seconds);
        redlight.SetActive(false);
        greenlight.SetActive(true);

        potCooking.transform.GetChild(5).gameObject.SetActive(false);
        potCooking.transform.GetChild(3).gameObject.SetActive(true);

    }
}

