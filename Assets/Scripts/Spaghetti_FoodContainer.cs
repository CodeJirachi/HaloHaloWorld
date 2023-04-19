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
    [SerializeField] GameObject saucePot2;
    [SerializeField] GameObject saucePot3;
    [SerializeField] GameObject saucePot4;

    [SerializeField] GameObject pan;
    [SerializeField] GameObject pan2;
    [SerializeField] GameObject pan3;
    [SerializeField] GameObject pan4;
    [SerializeField] GameObject pan5;
    [SerializeField] GameObject pan6;

    public GameObject nextButton1;

    // result that comes out of pot and pan 
    [SerializeField] GameObject resultIcon;

    [SerializeField] GameObject potReset;

    //collander stuff
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

    //curr ingredient layer
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

            // raw spaghetti
            if (currentIngredient == "raw spaghetti")
            {
                potCooking.transform.GetChild(5).gameObject.SetActive(true);
                StartCoroutine(CookSpaghetti(5.0f));
                draggedObject.SetActive(false);
                //currentIngredient.SetActive(false);

                //after a few secconds, make the spaghetti submerge 

                //currIngredientLayer++;
                Debug.Log(currentIngredient);
            }

            else if (currentIngredient == "ketchup icon" && currIngredientLayer == 0)
            {
                saucePot.SetActive(true);
                draggedObject.SetActive(false);

                greenlight.SetActive(true);
                currIngredientLayer++;
            }
            else if (currentIngredient == "soy sauce icon" && currIngredientLayer == 1)
            {
                saucePot2.SetActive(true);
                draggedObject.SetActive(false);

                currIngredientLayer++;
            }
            else if (currentIngredient == "oyster sauce icon" && currIngredientLayer == 2)
            {
                saucePot3.SetActive(true);
                draggedObject.SetActive(false);

                currIngredientLayer++;
            }
            else if (currentIngredient == "sugar icon" && currIngredientLayer == 3)
            {
                saucePot4.SetActive(true);
                draggedObject.SetActive(false);

                greenlight.SetActive(false);
                currIngredientLayer++;
            }
            // fill collander with spaghetti 

            else if (currentIngredient == "spaghetti pot")
            {
                //collander.SetActive(false);
                filledCollander.SetActive(true);
                draggedObject.SetActive(false);

                greenlight.SetActive(false);

                if (potReset.activeSelf == false)
                {
                    potReset.SetActive(true);
                }
            }
            else if (currentIngredient == "garlic chopped")
            {
                pan.SetActive(true);
                draggedObject.SetActive(false);
                greenlight.SetActive(true);
                StartCoroutine(CookGarlic(1.0f));

            }
            //pan3
            else if (currentIngredient == "thai basil")
            {
                pan3.SetActive(true);
                draggedObject.SetActive(false);
            }
            else if (currentIngredient == "bell pepper chopped")
            {
                pan4.SetActive(true);
                draggedObject.SetActive(false);
            }
            else if (currentIngredient == "red chili chopped")
            {
                pan5.SetActive(true);
                draggedObject.SetActive(false);
            }
            else if (currentIngredient == "hot dog chopped")
            {
                pan6.SetActive(true);
                draggedObject.SetActive(false);

                nextButton1.SetActive(true);
            }

            else
            {
                Debug.Log(currentIngredient);
            }

        }
    }
    


    public void OnBeginDrag(PointerEventData eventData)
    {
        //without this the items generated from the stove won't move once they have been placed in the inventory bar 
        //resultIcon.GetComponent<IngredientDragDrop>().inSlot = true;
        
        if (greenlight.activeSelf && !resultIcon.GetComponent<IngredientDragDrop>().inSlot)
        {
            Debug.Log("begindrag");

            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;

            resultIcon.SetActive(true);
            resultIcon.GetComponent<IngredientDragDrop>().inSlot = false;
            resultIcon.GetComponent<RectTransform>().position = mousepos;
            resultIcon.GetComponent<Image>().raycastTarget = false; 
        }

    }

    public void OnDrag(PointerEventData eventData)
    {

        if (greenlight.activeSelf && !resultIcon.GetComponent<IngredientDragDrop>().inSlot)
        {
            resultIcon.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        resultIcon.GetComponent<IngredientDragDrop>().inSlot = true;

        if (greenlight.activeSelf)
        {
            if (!resultIcon.GetComponent<IngredientDragDrop>().inSlot)
            {
                resultIcon.SetActive(false);
            }
        }

        potEmpty.SetActive(false);
        greenlight.SetActive(false);
         
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

        potCooking.transform.GetChild(5).gameObject.SetActive(false);
        potCooking.transform.GetChild(3).gameObject.SetActive(true);

    }

    private IEnumerator CookGarlic(float seconds)
    {


        yield return new WaitForSeconds(seconds);

        pan2.SetActive(true);
      

    }
}


