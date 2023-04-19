using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LechonPot : MonoBehaviour, IDropHandler
{
    public Canvas canvas;

    public GameObject lechonLayer;
    public GameObject starAniseLayer;
    public GameObject chiliLayer;
    public GameObject garlicLayer;
    public GameObject greenOnionLayer;

    //fake layers
    public GameObject saltLayer;
    public GameObject pepperLayer;

    GameObject currentIngredient;
    string currIngredientName;

    //for end condition of scene
    public int tracker; 
    public FusionDishStepManager fdsm;

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            currentIngredient = eventData.pointerDrag;
            currIngredientName = currentIngredient.GetComponent<RectTransform>().name;

            switch(currIngredientName)
            {
                case "raw pork belly":
                    lechonLayer.SetActive(true);
                    currentIngredient.SetActive(false);
                    tracker++;
                    break;
                case "star anise":
                    starAniseLayer.SetActive(true);
                    currentIngredient.SetActive(false);
                    tracker++;
                    break;
                case "chili icon(Clone)":
                    chiliLayer.SetActive(true);
                    currentIngredient.SetActive(false);
                    tracker++;
                    break;
                case "chopped garlic icon(Clone)":
                    garlicLayer.SetActive(true);
                    currentIngredient.SetActive(false);
                    tracker++;
                    break;
                case "chopped green onion(Clone)":
                    greenOnionLayer.SetActive(true);
                    currentIngredient.SetActive(false);
                    tracker++;
                    break;
                case "salt":
                    saltLayer.SetActive(true);
                    currentIngredient.SetActive(false);
                    tracker++;
                    break;
                case "peppercorn":
                    pepperLayer.SetActive(true);
                    currentIngredient.SetActive(false);
                    tracker++;
                    break;
            }
        }
    }

    void Update()
    {
        if (tracker == 7) fdsm.finishTrigger = true;
    }
}
