using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class cookingManager : MonoBehaviour
{
    //serialize game obj for each input of ingred. in glass
    /*
    [SerializeField] GameObject glassEmpty;
    [SerializeField] GameObject ice;
    [SerializeField] GameObject beans;
    [SerializeField] GameObject nataDeCoco;
    [SerializeField] GameObject lecheFlan;
    [SerializeField] GameObject stickoComplete;
    */

    [SerializeField] TMP_Text recipeTitle;
    [SerializeField] TMP_Text recipeContent;

    public void Start()
    {
        //current scene will determine recipe 
        //temp reference current scene 
        Scene currentScene = SceneManager.GetActiveScene();

        //name of current scene -> retrieve 
        string sceneName = currentScene.name;
        string choiceTest = "choice test ingredient";

        if (sceneName == "HaloHalo")
        {
            //yay this works, nice 
            recipeTitle.text = "Halo Halo";
            recipeContent.text = "1. test" + choiceTest;
        }
         
        //spaghetti gameplay scenes: 
        //else if (sceneName == "Spaghetti0" || || || )
        else if (sceneName == "Spaghetti0")
        {
            recipeTitle.text = "Thai Style Spaghetti";
            recipeContent.text = "";
            // recipe + choice 
        }
         
    }

    // jira choice code attempt
    public static void GetDecision()
    {
        //halohalo
    }

    // jira
    
}
