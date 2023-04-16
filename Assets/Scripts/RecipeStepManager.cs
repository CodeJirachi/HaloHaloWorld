using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecipeStepManager : MonoBehaviour
{
    //handles the "step" a recipe is on in order determine what the next button goes to 
    //the idea is on scene-by-scene basis, call RecipeStepManager.RSM.step to change the step, then instantiate a button with the right function call

    public static RecipeStepManager RSM;

    public Canvas canvas;

    public GameObject nextButtonPrefab;
    GameObject nextButton;

    //again not sure if a better way to do this

    //for rice cooking
    public GameObject riceCooker;

    //for chopping
    public GameObject cuttingBoard;

    //for stove cooking
    public GameObject stovetop;

    //for mixing 1
    public GameObject mixingBowl;

    //for mixing 2
    public GameObject saucepan;

    //for fusion final plating
    public GameObject plating;

    //must be a better way to do this...
    public GameObject bar1;

    public GameObject bar2;
    public GameObject bar3;

    public GameObject bar4;
    public GameObject bar5;

    public GameObject bar6;
    public GameObject bar7;

    public GameObject bar8;

    public GameObject bar9;

    public GameObject bar10;

    public GameObject barEmpty;

    public int step; // to check which step you're on? 
    string scene_name;

    void Start()
    {
        //check what scene/recipe it is
        scene_name = SceneManager.GetActiveScene().name;
        step = 1;

        if (scene_name == "FusionDish")
        {
            //set first step with rice cooking stuff
        }
    }

    private void Update()
    {
        if(scene_name == "FusionDish")
        {
            switch(step)
            {
                case 1: //the step of the final dish
                    //end condition
                    if (GameObject.Find("cooked rice") != null && GameObject.Find("cooked rice").activeSelf && GameObject.Find("cooked rice").GetComponent<IngredientDragDrop>().inSlot) 
                    {
                        setButton(new string[]{"cutting board"}, new string[] { }, false);
                        step++;
                    }

                    //set up inventory here
                    

                    break;
                default:
                    break;
            }
        }
    }

    //do everything here
    //++ to step
    //add 2 listeners to button (which functions that button will have) - contains what to activate/deactivate, kitchenware and ingredients wise
    void setButton(string[] kitchenware, string[] ingredients, bool keepInventory)
    {
        nextButton = Instantiate(nextButtonPrefab, canvas.transform);
        nextButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(348, 0);

        nextButton.GetComponent<Button>().onClick.AddListener(deactivateAll);

        //maybe a better way to do this somehow??
        foreach (string k in kitchenware)
        {
            switch(k)
            {
                case "rice cooker":
                    nextButton.GetComponent<Button>().onClick.AddListener(delegate { riceCooker.SetActive(true); });
                    break;
                case "cutting board":
                    nextButton.GetComponent<Button>().onClick.AddListener(delegate { cuttingBoard.SetActive(true); });
                    break;
                case "stovetop":
                    nextButton.GetComponent<Button>().onClick.AddListener(delegate { stovetop.SetActive(true); });
                    break;
                case "mixing bowl":
                    nextButton.GetComponent<Button>().onClick.AddListener(delegate { mixingBowl.SetActive(true); });
                    break;
                case "saucepan":
                    nextButton.GetComponent<Button>().onClick.AddListener(delegate { saucepan.SetActive(true); });
                    break;
                case "plating":
                    nextButton.GetComponent<Button>().onClick.AddListener(delegate { plating.SetActive(true); });
                    break;
            }
        }
    }

    void deactivateAll()
    {
        if(riceCooker != null)riceCooker.SetActive(false);
        if (cuttingBoard != null) cuttingBoard.SetActive(false);
        if (stovetop != null) stovetop.SetActive(false);
        if (mixingBowl != null) mixingBowl.SetActive(false);
        if (saucepan != null) saucepan.SetActive(false);
        if (plating != null) plating.SetActive(false);
    }

}
