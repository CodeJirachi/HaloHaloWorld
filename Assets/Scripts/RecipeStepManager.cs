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

    public int step; // to check which step you're on? 
    string scene_name;

    void Start()
    {
        //check what scene/recipe it is
        scene_name = SceneManager.GetActiveScene().name;
        step = 1;
    }

    private void Update()
    {
        if(scene_name == "FusionDish")
        {
            switch(step)
            {
                case 1: //the step of the final dish
                    if(GameObject.Find("cooked rice icon") != null && GameObject.Find("cooked rice icon").activeSelf) //end condition
                    {
                        setButton(new string[]{"cutting board"}, new string[] { }, false);
                    }
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
        nextButton.GetComponent<Button>().onClick.AddListener(delegate { step++; });

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
        riceCooker.SetActive(false);
        cuttingBoard.SetActive(false);
        stovetop.SetActive(false);
        mixingBowl.SetActive(false);
        saucepan.SetActive(false);
        plating.SetActive(false);
    }

}
