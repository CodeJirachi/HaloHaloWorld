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
    //audrey code is above this
    

    //affected by tool Item not needed in kitchen manager

    public void SelectTool(string name)
    {
        switch(name)
        {
            case "knife":
                //tool.SetActive(!tool.activeSelf);
                knife.SetActive(!knife.activeSelf);
                break;
            //case "spoon":
            case "no knife":
                knife.SetActive(false);
                break;
            case "spoon":
                spoon.SetActive(!spoon.activeSelf);
                break;
            case "no spoon":
                spoon.SetActive(false);
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


    
}
