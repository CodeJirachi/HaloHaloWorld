using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject recipeButton;
    [SerializeField] GameObject settingsButton;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject recipePage;

    public void Start()
    {
        //for testing choice tracking
        //Debug.Log(ChoiceTracker.CT.testVar);
        Debug.Log(ChoiceTracker.CT.choice);
    }

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

    public void openSettings()
    {
        //use prefab of settings/menus, or LoadLevelAdditive
    }

    public void startGame()
    {
        //temp name
        SceneManager.LoadScene("VN testing");
    }

    public void quitGame()
    {
        //Application.Quit(); //use this for when actually deploying game
        UnityEditor.EditorApplication.isPlaying = false; //this is temporary, just for editor purposes
    }
}
