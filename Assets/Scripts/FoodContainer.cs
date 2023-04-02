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

    public string currentIngredient;
    GameObject draggedObject; 

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

            if (currentIngredient == "inventoryBeans")
            {
                beans.SetActive(true);
            }
            else if (currentIngredient == "half filled ice bowl PLACEHOLDER"){
                ice.SetActive(true);
                draggedObject.SetActive(false);
            }
        }
    }

}
