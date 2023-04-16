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
                choiceText = "Ube";
                //this works 
            }

            else
            {
                //default
                choiceText = "???";
            }
            
            //yay this works, nice 
            recipeTitle.text = "Halo Halo";
            recipeContent.text = "You will need a Spoon for this recipe!! \n\n" + "1. pour Ice in the glass \n\n" +
                "2. scoop in a layer of Beans \n\n" + "3. scoop in a few slices of Jackfruit \n\n" +
                "4. follow with a nice layer of Nata De Coco \n\n" + "5. scoop in some Banana Slices \n\n" + "6. follow with a nice scoop of " + choiceText +
                " Ice Cream \n\n" + "7. add in some Leche Flan \n\n" + "8. spoon over a nice drizzle of Evaporated ilk \n\n" + "9. lastly, finish with a Sticko to top it all off!";
        }
         
        //spaghetti gameplay scenes: 
        //else if (sceneName == "Spaghetti0" || || || )
        else if (sceneName == "Spaghetti0")
        {
            if (ChoiceTracker.CT.choice == "Thai Basil")
            {
                choiceText = "thai basil";
            }
            else
            {
                //default
                choiceText = "???";
            }

            recipeTitle.text = "Thai Style Spaghetti";
            recipeContent.text = "";
            // recipe + choice 
        }
         
    }
    
}
