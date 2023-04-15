using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class Spaghetti_FoodContainer : MonoBehaviour, IDropHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public string currentItem;
    // game objects for ingredients that goes into pot
    [SerializeField] GameObject potEmpty;
    [SerializeField] GameObject rawSpaghetti;
    [SerializeField] GameObject underwaterSpaghetti;
    [SerializeField] GameObject saucePot;

    // populate the new ingredient from the pot
    // result of cooking stage 
    [SerializeField] GameObject resultIcon;

    [SerializeField] GameObject potReset;
    [SerializeField] GameObject collander;
    [SerializeField] GameObject filledCollander;

    //pot not done 
    public GameObject redlight;
    //indicates pot done boiling 
    public GameObject greenlight;

    public Canvas canvas;
  
    // game objects for ingredients that goes into pan
    //[SerializeField] GameObject dfgfdgfdgfd;

    // OG state of pot and pan on stovetop 
    public GameObject potCooking;
    public GameObject panCooking;

    public string currentIngredient;
    GameObject draggedObject;

    Vector2 currentPrevPosition;

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
            draggedObject = eventData.pointerDrag;
            currentIngredient = draggedObject.name;
            //currentIngredient = draggedObject.name;
            //currentItem = currentIngredient.GetComponent<RectTransform>().name;
            //currentPrevPosition = currentIngredient.GetComponent<IngredientDragDrop>().prev_pos;

            // fill collander with spaghetti 
            /*
            if (currentIngredient == "spaghetti pot")
            {
                //collander.SetActive(false);
                filledCollander.SetActive(true);
                draggedObject.SetActive(false);

                //greenlight.SetActive(false);

                if (potReset.activeSelf == false)
                {
                    potReset.SetActive(true);
                }

            }
             * */

            // raw spaghetti
            if (currentIngredient == "raw spaghetti" && currIngredientLayer == 0)
            {
                potCooking.transform.GetChild(3).gameObject.SetActive(true);
                StartCoroutine(CookSpaghetti(5.0f));
                draggedObject.SetActive(false);
                //currentIngredient.SetActive(false);

                //after a few secconds, make the spaghetti submerge 

                //currIngredientLayer++;
                Debug.Log(currentIngredient);
            }

            else if (currentIngredient == "sauce")
            {
                saucePot.SetActive(true);
                draggedObject.SetActive(false);
<<<<<<< HEAD
                greenlight.SetActive(true);
=======
            }

            // fill collander with spaghetti 
            else if (currentIngredient == "potFilled X")
            {
                //collander.SetActive(false);
                filledCollander.SetActive(true);
                draggedObject.SetActive(false);

                greenlight.SetActive(false);

                if (potReset.activeSelf == false)
                {
                    potReset.SetActive(true);
                }
>>>>>>> c277f3e9739564e6fc861fd4235737c75697d2c1

            }
 
            else
            {
                Debug.Log(currentIngredient);
            }

        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        
            if (greenlight.activeSelf && resultIcon.GetComponent<IngredientDragDrop>().inSlot)
            {
                Debug.Log("begindrag");

                Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousepos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

                resultIcon.SetActive(true);
                
                resultIcon.GetComponent<IngredientDragDrop>().inSlot = false;
                resultIcon.GetComponent<RectTransform>().position = mousepos;
                resultIcon.GetComponent<Image>().raycastTarget = false;
            }

            //without this it wont drag after apparently idfk    
            //resultIcon.GetComponent<IngredientDragDrop>().inSlot = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //resultIcon.GetComponent<IngredientDragDrop>().inSlot = true;

        if (greenlight.activeSelf && !resultIcon.GetComponent<IngredientDragDrop>().inSlot)
        {
            resultIcon.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;

        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        resultIcon.GetComponent<IngredientDragDrop>().inSlot = true;
        potEmpty.SetActive(false);
       /*if (greenlight.activeSelf)
        {
            if (!resultIcon.GetComponent<IngredientDragDrop>().inSlot)
            {
                resultIcon.SetActive(false);
            }
        }
        
       
        */
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    private IEnumerator CookSpaghetti(float seconds)
    {
        redlight.SetActive(true);

        yield return new WaitForSeconds(seconds);

        redlight.SetActive(false);
        greenlight.SetActive(true);

        potCooking.transform.GetChild(3).gameObject.SetActive(false);
        underwaterSpaghetti.SetActive(true);

    }
}

