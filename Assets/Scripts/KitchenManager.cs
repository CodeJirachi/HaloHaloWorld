using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for the "buttons" involved in cooking (selecting a tool, chopping, etc.)

public class KitchenManager : MonoBehaviour
{
    public GameObject knife;

    public GameObject chili;
    public int ingredientStage;
    public int ingredientStageMax;

    public void SelectTool(string name)
    {
        switch(name)
        {
            case "knife":
                knife.SetActive(!knife.activeSelf);
                break;
            case "spoon":
                knife.SetActive(false);
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
}
