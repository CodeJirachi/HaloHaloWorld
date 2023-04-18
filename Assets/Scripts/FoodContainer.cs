using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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


    public GameObject dialoguePopup;
    public GameObject dialogueText;
    public GameObject nameText;

    TextMeshProUGUI speakerName;
    TextMeshProUGUI message;

    bool inPopup;

    public void Awake()
    {
        currIngredientLayer = 0;
    }

    public void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && inPopup)
        {
            //hide pop up
            dialoguePopup.SetActive(false);
            inPopup = false;
        }
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

            if(currentIngredient == "shaved ice" && currIngredientLayer == 0)
            {
                halohalo.transform.GetChild(11).gameObject.SetActive(true);
                draggedObject.SetActive(false);
                currIngredientLayer++;
            }
            else if (currentIngredient == "sweetened beans" && currIngredientLayer == 1)
            {
                halohalo.transform.GetChild(10).gameObject.SetActive(true);
                draggedObject.SetActive(false);
                currIngredientLayer++;
            }
           
            // should be jackfruit 
            else if (currentIngredient == "jackfruit" && currIngredientLayer == 2)
            {
                halohalo.transform.GetChild(9).gameObject.SetActive(true);
                draggedObject.SetActive(false);
                currIngredientLayer++;
            }
            else if (currentIngredient == "nata de coco" && currIngredientLayer == 3)
            {
                halohalo.transform.GetChild(8).gameObject.SetActive(true);
                draggedObject.SetActive(false);
                currIngredientLayer++;
            }
            else if (currentIngredient == "saba (banana)" && currIngredientLayer == 4)
            {
                halohalo.transform.GetChild(7).gameObject.SetActive(true);
                draggedObject.SetActive(false);
                currIngredientLayer++;
            }
            else if (currentIngredient == "ube ice cream" && currIngredientLayer == 5)
            {
                halohalo.transform.GetChild(4).gameObject.SetActive(true);
                draggedObject.SetActive(false);
                currIngredientLayer++;
            }
            // is allowed to be dragged in, this is THE WRONG CHOICE!!!!!!!! ITS WRONG YO!!! 
            else if (currentIngredient == "mint choco chip ice cream" && currIngredientLayer == 5)
            {
                halohalo.transform.GetChild(5).gameObject.SetActive(true);
                draggedObject.SetActive(false);
                currIngredientLayer++;
            }
            else if (currentIngredient == "flan" && currIngredientLayer == 6)
            {
                halohalo.transform.GetChild(6).gameObject.SetActive(true);
                draggedObject.SetActive(false);
                currIngredientLayer++;
            }
            else if (currentIngredient == "evaporated milk" && currIngredientLayer == 7)
            {
                halohalo.transform.GetChild(3).gameObject.SetActive(true);
                draggedObject.SetActive(false);
                currIngredientLayer++;
            }
            else if (currentIngredient == "sticko" && currIngredientLayer == 8)
            {
                halohalo.transform.GetChild(12).gameObject.SetActive(true);
                draggedObject.SetActive(false);
                currIngredientLayer++;

                StartCoroutine(delaySceneSwitch(5.0f));
            }
            else
            {
                //show popup
                inPopup = true;
                dialoguePopup.SetActive(true);
                nameText.GetComponent<TMPro.TextMeshProUGUI>().text = "Jasmine";
                dialogueText.GetComponent<TMPro.TextMeshProUGUI>().text = "Well... that's certainly a choice.";
                Debug.Log("wrong ingredient >:(");
            }


        }
    }

    private IEnumerator delaySceneSwitch(float seconds)
    {

        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("PreSpaghetti");

    }

}
