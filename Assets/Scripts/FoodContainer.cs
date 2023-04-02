using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodContainer : MonoBehaviour, IDropHandler
{
    //serialize game obj for each input of ingred. in glass
    [SerializeField] GameObject glassEmpty;
    [SerializeField] GameObject ice;
    [SerializeField] GameObject beans;
    [SerializeField] GameObject nataDeCoco;
    [SerializeField] GameObject lecheFlan;
    [SerializeField] GameObject stickoComplete;

    public GameObject halohalo;

    public string currentIngredient;
    GameObject draggedObject;

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
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().Destroy();
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            //currentIngredient = eventData.pointerDrag.GetComponent<RectTransform>().name;

            draggedObject = eventData.pointerDrag;
            currentIngredient = draggedObject.name;

            Debug.Log(currentIngredient);

            /*
            if (currentIngredient == "inventoryBeans")
            {
                beans.SetActive(true);
            }
            else if (currentIngredient == "half filled ice bowl PLACEHOLDER"){
                ice.SetActive(true);
                draggedObject.SetActive(false);
            }
            */

            //maybe dont do a switch
            /*
            switch(currentIngredient)
            {
                case "TEMP ice":
                    halohalo.transform.GetChild(10).gameObject.SetActive(true);
                    draggedObject.SetActive(false);
                    break;
                case "TEMP beans":
                    halohalo.transform.GetChild(9).gameObject.SetActive(true);
                    draggedObject.SetActive(false);
                    break;
                default:
                    Debug.Log("wrong ingredient >:(");
                    //wrong ingredient
                    break;
            }
            */

            if(currentIngredient == "TEMP ice" && currIngredientLayer == 0)
            {
                halohalo.transform.GetChild(10).gameObject.SetActive(true);
                draggedObject.SetActive(false);
                currIngredientLayer++;
            } else if(currentIngredient == "TEMP beans" && currIngredientLayer == 1)
            {
                halohalo.transform.GetChild(9).gameObject.SetActive(true);
                draggedObject.SetActive(false);
                currIngredientLayer++;
            } else
            {
                Debug.Log("wrong ingredient >:(");
            }
        }
    }

}
