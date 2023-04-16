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

        //default choice is "???"
        string choiceText = "???";

        if (sceneName == "HaloHalo 1")
        {
            
            //
            if (ChoiceTracker.CT.choice == "Ube, always have it on me!")
            {
                choiceText = "ube";
                //this works 
            }
            else
            {
                //default
                choiceText = "???";
            }
            
            //yay this works, nice 
            recipeTitle.text = "Halo Halo";
            recipeContent.text = "1. use the ice machine to shave down ice \n" + 
                "2. scoop shaved ice into glass \n" + "3. follow with beans \n" + "4. follow with nata de coco \n" + "5. follow with leche flan \n" + 
                "6. follow with " + choiceText + " ice cream \n" + "7. finally, finish with a sticko on top!";
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
    
}
