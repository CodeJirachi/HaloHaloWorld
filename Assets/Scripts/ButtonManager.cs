using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject recipeButton;
    [SerializeField] GameObject setButton;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject recipePage;

    public void openRecipe()
    {
        recipeButton.SetActive(false);
        setButton.SetActive(false);
        exitButton.SetActive(true);
        recipePage.SetActive(true);
    }

    public void closeRecipe()
    {
        recipeButton.SetActive(true);
        setButton.SetActive(true);
        exitButton.SetActive(false);
        recipePage.SetActive(false);

    }

}
