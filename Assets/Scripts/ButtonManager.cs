using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject recipeButton;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject recipePage;

    public void Start()
    {
        Debug.Log(ChoiceTracker.CT.testVar);
    }

    public void openRecipe()
    {
        recipeButton.SetActive(false);
        exitButton.SetActive(true);
        recipePage.SetActive(true);
    }

    public void closeRecipe()
    {
        recipeButton.SetActive(true);
        exitButton.SetActive(false);
        recipePage.SetActive(false);
    }

}
