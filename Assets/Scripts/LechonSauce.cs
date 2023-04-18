using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LechonSauce : MonoBehaviour, IDropHandler
{
    public bool completed;
    public bool sauteed;

    public GameObject oilLayer;
    public GameObject garlicLayer;
    public GameObject onionLayer;
    public GameObject cookedGarlicLayer;
    public GameObject cookedOnionLayer;

    public GameObject waterLayer;
    public GameObject vinegarLayer;

    public GameObject breadcrumbsLayer;
    public GameObject liverLayer;

    GameObject currentIngredient;
    string currIngredientName;

    public int tracker;

    void Start()
    {
        completed = false;
        sauteed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (tracker == 7) completed = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            currentIngredient = eventData.pointerDrag;
            currIngredientName = currentIngredient.GetComponent<RectTransform>().name;

            if(currIngredientName == "chopped garlic icon(Clone)")
            {
                garlicLayer.SetActive(true);
                currentIngredient.SetActive(false);
                tracker++;
            } else if(currIngredientName == "chopped onion(Clone)")
            {
                onionLayer.SetActive(true);
                currentIngredient.SetActive(false);
                tracker++;
            } else if (currIngredientName == "canola oil")
            {
                oilLayer.SetActive(true);
                currentIngredient.SetActive(false);
                tracker++;
            }

            else if(currIngredientName == "water" && sauteed)
            {
                waterLayer.SetActive(true);
                currentIngredient.SetActive(false);
                tracker++;
            }
            else if(currIngredientName == "vinegar" && sauteed)
            {
                vinegarLayer.SetActive(true);
                currentIngredient.SetActive(false);
                tracker++;
            }
            else if(currIngredientName == "breadcrumbs" && sauteed)
            {
                breadcrumbsLayer.SetActive(true);
                currentIngredient.SetActive(false);
                tracker++;
            } else if(currIngredientName == "liver" && sauteed)
            {
                liverLayer.SetActive(true);
                currentIngredient.SetActive(false);
                tracker++;
            }

            if (tracker == 3) StartCoroutine(Saute(5.0f));
        }
    }

    private IEnumerator Saute(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        garlicLayer.SetActive(false);
        cookedGarlicLayer.SetActive(true);
        onionLayer.SetActive(false);
        cookedOnionLayer.SetActive(true);
        sauteed = true;
    }
}
