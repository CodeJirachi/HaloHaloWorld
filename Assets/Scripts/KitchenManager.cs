using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    public GameObject knife;

    public GameObject chili;
    private int ingredientStage;

    public void Start()
    {
        ingredientStage = 0;
    }

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

    public void Chop(GameObject ingredient)
    {
        //EXTREMELY HACK-Y WAY
        //does not need to be chili - need to generalize these variables b/c you can pick what is the "ingredient" in inspector
        if(knife.activeSelf && ingredientStage < 4)
        {
            ingredient.transform.GetChild(ingredientStage).gameObject.SetActive(false);
            ingredientStage++;
            ingredient.transform.GetChild(ingredientStage).gameObject.SetActive(true);

            if(ingredientStage == 4)
            {
                //this deletes the button on top of the ingredient icon
                ingredient.transform.GetChild(6).gameObject.SetActive(false);

                //maybe reset ingredientStage here?
            }
            
        }
    }
}
