using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NamPrikPla : MonoBehaviour, IDropHandler
{
    public bool completed;

    public GameObject sugarLayer;
    public GameObject greenChiliLayer;
    public GameObject redChiliLayer;
    public GameObject garlicLayer;
    public GameObject fishSauceLayer;

    //fake layer just for checking
    public GameObject limeLayer;
    
    GameObject currentIngredient;
    string currIngredientName;

    public int tracker;

    // Start is called before the first frame update
    void Start()
    {
        completed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(tracker == 6) completed = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            currentIngredient = eventData.pointerDrag;
            currIngredientName = currentIngredient.GetComponent<RectTransform>().name;

            switch (currIngredientName)
            {
                case "chili icon(Clone)":
                    redChiliLayer.SetActive(true);
                    currentIngredient.SetActive(false);
                    tracker++;
                    break;
                case "green chili icon(Clone)":
                    greenChiliLayer.SetActive(true);
                    currentIngredient.SetActive(false);
                    tracker++;
                    break;
                case "chopped garlic icon(Clone)":
                    garlicLayer.SetActive(true);
                    currentIngredient.SetActive(false);
                    tracker++;
                    break;
                case "sugar":
                    sugarLayer.SetActive(true);
                    currentIngredient.SetActive(false);
                    tracker++;
                    break;
                case "fish sauce":
                    fishSauceLayer.SetActive(true);
                    currentIngredient.SetActive(false);
                    tracker++;
                    break;
                case "lime":
                    limeLayer.SetActive(true);
                    currentIngredient.SetActive(false);
                    tracker++;
                    break;
            }

        }
    }
}
