using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Stove : MonoBehaviour, IDropHandler
{
    //serialize game obj for each input of ingred. in glass
    [SerializeField] GameObject glassEmpty;
    [SerializeField] GameObject ice;
    [SerializeField] GameObject beansS;
    [SerializeField] GameObject nataDeCoco;
    [SerializeField] GameObject lecheFlan;
    [SerializeField] GameObject stickoComplete;

    //public GameObject halohalo;

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


            if (currentIngredient == "collanderParent")
            {
                beansS.SetActive(true);
                draggedObject.SetActive(false);
                //currIngredientLayer++;
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

}
