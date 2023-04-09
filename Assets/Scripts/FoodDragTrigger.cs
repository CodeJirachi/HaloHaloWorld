using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FoodDragTrigger : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject ingredient_icon;
    public Canvas canvas;

    public GameObject ingredientFinalStage;
    bool finalStage;

    // Update is called once per frame
    void Update()
    {
        if (ingredient_icon.GetComponent<IngredientDragDrop>().inSlot)
        {
            this.gameObject.SetActive(false);
        }

        if(GameObject.Find("chili 4 PLACEHOLDER").activeSelf)
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
