using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for the "buttons" involved in cooking (selecting a tool, chopping, etc.)

public class KitchenManager : MonoBehaviour
{
    //public GameObject tool;
    //tools: 
    public GameObject knife;
    public GameObject spoon;

    //these are public just so i can see for testing
    public int ingredientStage;
    public int ingredientStageMax;

    public int mixingStage; //for the sprite changing of the mixing
    public int mixingTriggerStage; //for the star triggers

    public FusionDishStepManager fdsm;
    public void Start()
    {
        mixingStage = 0;
        mixingTriggerStage = 0;
    }
    //audrey code is above this


    //affected by tool Item not needed in kitchen manager

    public void SelectTool(string name)
    {
        switch(name)
        {
            case "knife":
                knife.SetActive(!knife.activeSelf);
                spoon.SetActive(false);
                break;
            case "spoon":
                spoon.SetActive(!spoon.activeSelf);
                knife.SetActive(false);
                break;
            //case "pot":
                //tool.SetActive(!tool.activeSelf);
                //break;
        }
    }

    //set this method to the "button" under the ingredient to be chopped
    //also, make the button transparent and as big as the ingredient sprite
    public void Chop(GameObject ingredient)
    {
        ingredientStage = ingredient.GetComponent<FoodDragTrigger>().ingredientCurrStage;
        ingredientStageMax = ingredient.GetComponent<FoodDragTrigger>().ingredientMaxStage;

        //EXTREMELY HACK-Y WAY
        //if (knife.activeSelf && ingredientStage < ingredientStageMax)
        // if (tool.activeSelf && spoon.activeSelf && ingredientStage < ingredientStageMax)
        if (knife.activeSelf && ingredientStage < ingredientStageMax)
        {
            ingredient.transform.GetChild(ingredientStage).gameObject.SetActive(false);
            ingredient.GetComponent<FoodDragTrigger>().ingredientCurrStage++;
            ingredient.transform.GetChild(ingredient.GetComponent<FoodDragTrigger>().ingredientCurrStage).gameObject.SetActive(true);

            if(ingredientStage == ingredientStageMax)
            {
                ingredient.GetComponent<FoodDragTrigger>().ingredientCurrStage = 0;
            }
            
        }

    }

    public void Mix(GameObject ingredient)
    {
        ingredientStage = ingredient.GetComponent<FoodDragTrigger>().ingredientCurrStage;
        ingredientStageMax = ingredient.GetComponent<FoodDragTrigger>().ingredientMaxStage;

        //EXTREMELY HACK-Y WAY
        if (spoon.activeSelf && ingredientStage < ingredientStageMax)
        {
            ingredient.transform.GetChild(ingredientStage).gameObject.SetActive(false);
            ingredient.GetComponent<FoodDragTrigger>().ingredientCurrStage++;
            ingredient.transform.GetChild(ingredient.GetComponent<FoodDragTrigger>().ingredientCurrStage).gameObject.SetActive(true);

            if (ingredientStage == ingredientStageMax)
            {
                ingredient.GetComponent<FoodDragTrigger>().ingredientCurrStage = 0;
            }

        }

    }

    private void Update()
    {
        if (mixingStage > 6) fdsm.finishTrigger = true;
    }
}
