using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FusionDishStepManager : MonoBehaviour
{
    public static FusionDishStepManager FSM; //for accessing this class's variables
    public Canvas canvas;

    public GameObject nextButtonPrefab;
    GameObject nextButton;


    string scene_name;
    bool stepFinished; //for end condition of scene
    public bool finishTrigger;

    void Start()
    {
        scene_name = SceneManager.GetActiveScene().name;
        stepFinished = false;
        finishTrigger = false;
    }

    void Update()
    {
        if(scene_name == "FusionDish (NEW)")
        {
            //end condition
            if (!stepFinished && GameObject.Find("cooked rice") != null && GameObject.Find("cooked rice").activeSelf && GameObject.Find("cooked rice").GetComponent<IngredientDragDrop>().inSlot)
            { 
                stepFinished = true;

                //spawn next button
                nextButton = Instantiate(nextButtonPrefab, canvas.transform);
                nextButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(348, 0);
                nextButton.GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadScene("FusionDish Boiling Lechon"); });
            }
        } else if(scene_name == "FusionDish Boiling Lechon")
        {
            if(!stepFinished && finishTrigger) {
                stepFinished = true;
                finishTrigger=false;

                nextButton = Instantiate(nextButtonPrefab, canvas.transform);
                nextButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(348, 0);
                nextButton.GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadScene("FusionDish MixingNamPrikPla"); });
            }
        } else if(scene_name == "FusionDish MixingNamPrikPla")
        {
            if(!stepFinished && finishTrigger)
            {
                stepFinished = true;
                finishTrigger = false;

                nextButton = Instantiate(nextButtonPrefab, canvas.transform);
                nextButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(348, 0);
                nextButton.GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadScene("FusionDish MixingLechonSauce"); });
            }
        } else if(scene_name == "FusionDish MixingLechonSauce")
        {
            if(!stepFinished && finishTrigger)
            {
                stepFinished = true;
                finishTrigger = false;

                nextButton = Instantiate(nextButtonPrefab, canvas.transform);
                nextButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(348, 0);
                nextButton.GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadScene("FusionDish Frying"); });
            }
        } else if(scene_name == "FusionDish Frying")
        {
            if (!stepFinished && GameObject.Find("chopped lechon icon(Clone)") != null && GameObject.Find("chopped lechon icon(Clone)").activeSelf && GameObject.Find("chopped lechon icon(Clone)").GetComponent<IngredientDragDrop>().inSlot)
            {
                stepFinished = true;

                //spawn next button
                nextButton = Instantiate(nextButtonPrefab, canvas.transform);
                nextButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(348, 0);
                nextButton.GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadScene("FusionDish Assembly"); });
            }
        } else if(scene_name == "FusionDish Assembly")
        {
            if(!stepFinished && finishTrigger)
            {
                stepFinished = true;
                finishTrigger = false;

                nextButton = Instantiate(nextButtonPrefab, canvas.transform);
                nextButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(348, 0);
                nextButton.GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadScene("VN_FusionFlashback"); });
            }
        }
    }
}
