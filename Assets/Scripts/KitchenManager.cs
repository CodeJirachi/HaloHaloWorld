using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for the "buttons" involved in cooking (selecting a tool, chopping, etc.)

public class KitchenManager : MonoBehaviour
{
    public GameObject tool;
    //tools: 
    public GameObject knife;
    public GameObject spoon;

    //these are public just so i can see for testing
    public int ingredientStage;
    public int ingredientStageMax;

    //audrey code is above this
    public GameObject collander; 
    public GameObject pot;
    public GameObject pan;
    public GameObject saucepan;
    public GameObject measuringCup;

    //affected by tool Item not needed in kitchen manager

    public void SelectTool(string name)
    {
        switch(name)
        {
            case "knife":
                tool.SetActive(!tool.activeSelf);
                break;
            case "spoon":
                tool.SetActive(false);
                break;
            case "pot":
                tool.SetActive(!tool.activeSelf);
                break;
        }
    }

    //set this method to the "button" under the ingredient to be chopped
    //also, make the button transparent and as big as the ingredient sprite
    public void Chop(GameObject ingredient)
    {
        ingredientStage = ingredient.GetComponent<FoodDragTrigger>().ingredientCurrStage;
        ingredientStageMax = ingredient.GetComponent<FoodDragTrigger>().ingredientMaxStage;

        //EXTREMELY HACK-Y WAY
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
    
    public void Fill()
    {
        // JIRA!!!! fix so parts of pot dont disappear 
        //if (tool.activeSelf && ingredientStage < 3)
        //{
        //    chili.transform.
       //     chili.transform.GetChild(chiliStage).gameObject.SetActive(false);
        //    chiliStage++;
        //    chili.transform.GetChild(chiliStage).gameObject.SetActive(true);
       // }
    }
}
