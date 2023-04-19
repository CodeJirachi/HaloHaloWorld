using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpaghettiPlateFoodContainer : MonoBehaviour, IDropHandler
{
    public GameObject plate;

    public string currentIngredient;
    GameObject draggedObject;

    private int currIngredientLayer;

    public GameObject nextButton2;

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

            Debug.Log(currentIngredient);

            if (currentIngredient == "collanderParent FILLED" && currIngredientLayer == 0)
            {
                plate.transform.GetChild(0).gameObject.SetActive(true);
                draggedObject.SetActive(false);

                currIngredientLayer++;
            }
            else if (currentIngredient == "sauce pot" && currIngredientLayer == 1)
            {
                plate.transform.GetChild(1).gameObject.SetActive(true);
                draggedObject.SetActive(false);

                currIngredientLayer++;
            }
           
            else if (currentIngredient == "filled pan" && currIngredientLayer == 2)
            {
                plate.transform.GetChild(2).gameObject.SetActive(true);
                plate.transform.GetChild(3).gameObject.SetActive(true);
                plate.transform.GetChild(4).gameObject.SetActive(true);
                plate.transform.GetChild(5).gameObject.SetActive(true);

                draggedObject.SetActive(false);

                nextButton2.SetActive(true); ;
                currIngredientLayer++;
            }
            else
            {
                Debug.Log("wrong ingredient >:(");
            }


        }
    }
}
