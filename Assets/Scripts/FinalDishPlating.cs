using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FinalDishPlating : MonoBehaviour, IDropHandler
{
    bool ricePlated;
    GameObject currentIngredient;
    string currIngredientName;

    public GameObject riceLayer;
    public GameObject lechonLayer;
    public GameObject thaiSauceLayer;
    public GameObject filipinoSauceLayer;

    void Start()
    {
        ricePlated = false;
    }

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

            if(currIngredientName == "rice")
            {
                riceLayer.SetActive(true);
                ricePlated=true;
                currentIngredient.SetActive(false);
            } else if(currIngredientName == "chopped lechon" && ricePlated)
            {
                lechonLayer.SetActive(true);
                currentIngredient.SetActive(false);
            } else if(currIngredientName == "nam prik pla")
            {
                thaiSauceLayer.SetActive(true);
                currentIngredient.SetActive(false);
            } else if(currIngredientName == "lechon sauce")
            {
                filipinoSauceLayer.SetActive(true);
                currentIngredient.SetActive(false);
            }
        }
    }
}
