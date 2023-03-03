using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject recipeButton;
    [SerializeField] GameObject settingsButton;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject recipePage;

    public void openRecipe()
    {
        recipeButton.SetActive(false);
        settingsButton.SetActive(false);
        exitButton.SetActive(true);

        //recipe page opens + its contents show with it dynamically (HMM) 
        recipePage.SetActive(true);
        //recipe page must hold values that are set true or false depending on whether/ how they are toggled in VN gameplay 0
    }

    public void closeRecipe()
    {
        recipeButton.SetActive(true);
        settingsButton.SetActive(true);
        exitButton.SetActive(false);

        //recipe page closes
        recipePage.SetActive(false);
        //ensures the contents of it, closes with it

    }

}
