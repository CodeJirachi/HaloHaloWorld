using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject recipeButton;
    [SerializeField] GameObject settingsButton;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject recipePage;
    [SerializeField] GameObject recipeTitle;
    [SerializeField] GameObject recipeContent;

    public void Start()
    {
        //for testing choice tracking
        Debug.Log(ChoiceTracker.CT.testVar);
        Debug.Log(ChoiceTracker.CT.choice);
    }

    public void openRecipe()
    {
        recipeButton.SetActive(false);
        settingsButton.SetActive(false);
       
        exitButton.SetActive(true);

        //recipe page opens + its contents show with it dynamically (HMM) 
        recipePage.SetActive(true);
        recipeTitle.SetActive(true);
        recipeContent.SetActive(true);
        //recipe page must hold values that are set true or false depending on whether/ how they are toggled in VN gameplay 0
    }

    public void closeRecipe()
    {
        recipeButton.SetActive(true);
        settingsButton.SetActive(true);

        //recipe page closes
        recipePage.SetActive(false);
        recipeTitle.SetActive(false);
        recipeContent.SetActive(false);

        exitButton.SetActive(false);
        //ensures the contents of it, closes with it

    }

}
