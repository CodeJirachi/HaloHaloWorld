using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//attach this script to the parent gameobject of the ingredient to be chopped

public class FoodDragTrigger : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject ingredient_icon_prefab;
    public GameObject ingredient_icon;
    public Canvas canvas;

    GameObject curr_icon; //the one that pertains to this container

    public GameObject ingredientFinalStage; //set in inspector; the sprite of the very last "stage" of the chopped ingredient (when its fully chopped)
    public int ingredientCurrStage;
    public int ingredientMaxStage; //set in inspector; to determine how many sprites to go through
    bool finalStage;  

    void Start()
    {
        ingredientCurrStage = 0;

        //load in a new sprite icon from prefab - makes it so you can have multiple of the same thing chopped without using the same icon
        ingredient_icon = Instantiate(ingredient_icon_prefab, canvas.transform);
        ingredient_icon.GetComponent<RectTransform>().anchoredPosition = new Vector2(540, 120);
        ingredient_icon.GetComponent<IngredientDragDrop>().canvas = canvas;
        ingredient_icon.GetComponent<IngredientDragDrop>().inSlot = false;
    }

    void Update()
    {
        if (ingredient_icon.GetComponent<IngredientDragDrop>().inSlot)
        {
            this.gameObject.SetActive(false);
        }

        if(ingredientFinalStage.activeSelf)
        {
            finalStage = true;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (finalStage && !ingredient_icon.GetComponent<IngredientDragDrop>().inSlot)
        {
            Debug.Log("begindrag");

            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

            ingredient_icon.SetActive(true);
            ingredient_icon.GetComponent<IngredientDragDrop>().inSlot = false;
            ingredient_icon.GetComponent<RectTransform>().position = mousepos;
            ingredient_icon.GetComponent<Image>().raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (finalStage && !ingredient_icon.GetComponent<IngredientDragDrop>().inSlot)
        {
            ingredient_icon.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (finalStage && !ingredient_icon.GetComponent<IngredientDragDrop>().inSlot) {
            ingredient_icon.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
