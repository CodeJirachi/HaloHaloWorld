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
    [SerializeField] TMP_Text recipeContent2;

    public void Start()
    {
        //current scene will determine recipe 
        //temp reference current scene 
        Scene currentScene = SceneManager.GetActiveScene();

        //name of current scene -> retrieve 
        string sceneName = currentScene.name;

        //default choice is "???"
        string choiceText = "???";

        //if (sceneName == "HaloHalo 1")
        if (sceneName == "HaloHalo Final (audrey)")
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

            // add multiple pages
            recipeContent.text = "You will need a Spoon for this recipe!! \n\n" + "1. pour Ice in the glass \n\n" +
                "2. scoop in a layer of Beans \n\n" + "3. scoop in a few slices of Jackfruit \n\n" +
                "4. follow with a nice layer of Nata De Coco \n\n" + "5. scoop in some Banana Slices \n\n"; 
                
             recipeContent2.text = "6. follow with a nice scoop of " + choiceText +
                " Ice Cream \n\n" + "7. add in some Leche Flan \n\n" + "8. spoon over a nice drizzle of Evaporated Milk \n\n" + "9. lastly, finish with a Sticko to top it all off!";
        }
         
        //spaghetti gameplay scenes: 
        //else if (sceneName == "Spaghetti0" || || || )
        else if (sceneName == "Spaghetti 1(COPY) (JIRA) 1 COPY SAFE")
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

            recipeTitle.text ="<size=36%>Thai Style Spaghetti";
            recipeContent.text = "1. Bring the pot to sink and fill with water, then bring this over to the stovetop to boil \n" + "2. Put the colander in the sink to prep for straining \n"
                + "3. Put raw spaghetti in the boiling pot to cook \n" + "4. Drain the spaghetti filled pot in the colander \n" + "5. remove the colander from the sink into inventory \n"
                + "6. Drag the pot again to the stovetop, this time to cook the sauce \n" + "7. to the pot, add tomato ketchup first \n";
            recipeContent2.text = "8. then, add soy sauce \n"
                + "9. add oyster sauce \n" + "10. add sugar, then drag off stovetop \n" + "11. bring up the cutting board to chop bell pepper, hot dog, garlic, and thai chili using the Knife \n" + "12. After cutting upe verything, put the cutting board away and drag the pan over to the stovetop \n"
                + "13. First, cook the chopped garlic until it browns \n" + "14. Then add the thai chili, the " + choiceText + ", and the bell peppers \n" + "15. Lastly, add the hot dogs in to stir fry \n"
                + "16. Drag the filled pan to the inventory to be ready to plate \n" + "17. Plate the cooked spaghetti first \n" + "18. Top with the sauce, followed by the cooked ingredients from the pan";
                
            // recipe + choice 
        }

        else if(sceneName == "FusionDish (NEW)" || sceneName == "FusionDish Assembly" || sceneName == "FusionDish Boiling Lechon" || sceneName == "FusionDish Frying" || sceneName == "FusionDish MixingLechonSauce" || sceneName == "FusionDish MixingNamPrikPla")
        {

            if (ChoiceTracker.CT.choice == null)
            {
                choiceText = "";
            
                recipeTitle.text = "<size=36%>Moo Kob Nam Prik/Lechon Kawali Fusion" +choiceText;
                recipeContent.text = "1. Cook the rice.\n2. Chop garlic, green onion, and red thai chili.\n3. Boil water.\n4. Add raw pork belly, chopped ingredients, star anise, salt, and peppercorn to pot.\n5. While belly boils, make Nam Prik Pla - chop thai chilies and garlic.";
                recipeContent2.text = "6. Mix together chopped ingredients, sugar, fish sauce, and lime.\n7. Make lechon sauce - chop and saute onion and garlic.\n8. After sauteing, add vinegar, water, chicken liver, & breadcrumbs.\n9. Stir sauce until it thickens.\n10. After belly boils, put oil in pan and fry pork belly.\n11. Chop fried pork belly.\n12. Assemble and enjoy!";
            }
            else 
            {
                recipeTitle.text = "<size=36%>Moo Kob Nam Prik/Lechon Kawali Fusion" + choiceText;
                recipeContent.text = "1. Cook the rice.\n2. Chop garlic, green onion, and red thai chili.\n3. Boil water.\n4. Add raw pork belly, chopped ingredients, star anise, salt, and peppercorn to pot.\n5. While belly boils, make Nam Prik Pla - chop thai chilies and garlic.";
                recipeContent2.text = "6. Mix together chopped ingredients, sugar, fish sauce, and lime.\n7. Make lechon sauce - chop and saute onion and garlic.\n8. After sauteing, add vinegar, water, chicken liver, & breadcrumbs.\n9. Stir sauce until it thickens.\n10. After belly boils, put oil in pan and fry pork belly.\n11. Chop fried pork belly.\n12. Assemble and enjoy!";
            }

        }
    }
    
}
