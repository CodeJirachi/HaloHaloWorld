using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject recipeButton;
    [SerializeField] GameObject settingsButton;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;
    [SerializeField] GameObject recipePage;
    //[SerializeField] Object nextScene;
    [SerializeField] GameObject recipeTitle;
    [SerializeField] GameObject recipeContent;

    [SerializeField] GameObject cuttingBoard;
    [SerializeField] GameObject mixingBowl;

    public GameObject sinkFront; //for hiding sink front when cutting board opens

    public void Awake()
    {
        //for testing choice tracking
        //Debug.Log(ChoiceTracker.CT.testVar);
        //Debug.Log(ChoiceTracker.CT.choice);

        //current scene will determine recipe 
        //temp reference current scene 
        //Scene currentScene = SceneManager.GetActiveScene();
        //name of current scene -> retrieve 
        //string sceneName = currentScene.name;

    }

    public void openRecipe()
    {
        recipeButton.SetActive(false);
        //settingsButton.SetActive(false);
       
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
        //settingsButton.SetActive(true);

        //recipe page closes
        recipePage.SetActive(false);
        recipeTitle.SetActive(false);
        recipeContent.SetActive(false);

        exitButton.SetActive(false);
        //ensures the contents of it, closes with it

    }

    // change these to NEXT click 
    public void leftClick()
    {
        //current scene will determine recipe 
        //temp reference current scene 
        Scene currentScene = SceneManager.GetActiveScene();
        //name of current scene -> retrieve 
        string sceneName = currentScene.name;

        Debug.Log("F1 reads " + sceneName);
        if (sceneName == "Spaghetti0")
        {
            //go to sink scene on button press
            SceneManager.LoadScene("Spaghetti1");
        }
        else if (sceneName == "Spaghetti2")
        {
            SceneManager.LoadScene("Spaghetti0");
        }
    }
    public void rightClick()
    {
        //current scene will determine recipe 
        //temp reference current scene 
        Scene currentScene = SceneManager.GetActiveScene();
        //name of current scene -> retrieve 
        string sceneName = currentScene.name;

        Debug.Log("F2 reads" + sceneName);
        if (sceneName == "Spaghetti0")
        {
            //go to cuttingboard scene on button press
            SceneManager.LoadScene("Spaghetti2");
        }
        else if (sceneName == "Spaghetti1")
        {
            SceneManager.LoadScene("Spaghetti0");
        }

    }

    public void openSettings()
    {
        //use prefab of settings/menus, or LoadLevelAdditive
    }

    //for opening the chopping board/mixing bowl bird's eye view
    public void openView(GameObject self)
    {  
        switch(self.name)
        {
            case "cutting board":
                cuttingBoard.SetActive(true);
                sinkFront.SetActive(false);
                break;
            case "mixing bowl":
                mixingBowl.SetActive(true);
                self.SetActive(false);
                break;
            case "saucepan":
                break;
        }
    }

    public void closeView()
    {
        if(GameObject.Find("cutting board open").activeInHierarchy)
        {
            GameObject.Find("cutting board open").SetActive(false);
            sinkFront.SetActive(true);
        }
    }

    public void startGame(Object nextScene)
    {
        //temp name
        SceneManager.LoadScene("PreHaloHalo");
    }

    public void quitGame()
    {
        Application.Quit(); //use this for when actually deploying game
        //UnityEditor.EditorApplication.isPlaying = false; //this is temporary, just for editor purposes
    }
}
