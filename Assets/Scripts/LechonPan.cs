using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LechonPan : MonoBehaviour, IDropHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    GameObject currentIngredient;
    string currIngredientName;

    public GameObject oilLayer;
    public GameObject boiledBellyLayer;
    public GameObject friedBellyLayer;

    public GameObject friedBelly;

    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            currentIngredient = eventData.pointerDrag;
            currIngredientName = currentIngredient.GetComponent<RectTransform>().name;

            if (currIngredientName == "canola oil")
            {
                oilLayer.SetActive(true);
                currentIngredient.SetActive(false);
            } else if (currIngredientName == "boiled pork belly")
            {
                boiledBellyLayer.SetActive(true);
                currentIngredient.SetActive(false);
            }


            if(boiledBellyLayer.activeInHierarchy && oilLayer.activeInHierarchy)
            {
                StartCoroutine(FryLechon(5.0f));
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (friedBellyLayer.activeSelf && !friedBelly.GetComponent<IngredientDragDrop>().inSlot)
        {
            Debug.Log("begindrag");

            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

            friedBelly.SetActive(true);
            friedBelly.GetComponent<IngredientDragDrop>().inSlot = false;
            friedBelly.GetComponent<RectTransform>().position = mousepos;
            friedBelly.GetComponent<Image>().raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (friedBellyLayer.activeSelf && !friedBelly.GetComponent<IngredientDragDrop>().inSlot)
        {
            friedBelly.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (friedBellyLayer.activeSelf)
        {
            if (!friedBelly.GetComponent<IngredientDragDrop>().inSlot)
            {
                friedBelly.SetActive(false);
            } else
            {
                friedBellyLayer.SetActive(false);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    private IEnumerator FryLechon(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        boiledBellyLayer.SetActive(false);
        friedBellyLayer.SetActive(true);
    }
}
