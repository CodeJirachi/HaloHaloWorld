using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] GameObject recipeButton;
    [SerializeField] GameObject settingsButton;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;
    [SerializeField] GameObject recipePage;
    [SerializeField] GameObject recipeNext;
    [SerializeField] GameObject recipePrev;
    
    //[SerializeField] Object nextScene;
    [SerializeField] GameObject recipeTitle;
    [SerializeField] GameObject recipeContent1;
    [SerializeField] GameObject recipeContent2;


    //audio
    public AudioSource menuSelect;
    public AudioSource menuHover;

    //menu select
    public void playMenuSelect()
    {
        menuSelect.Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        menuHover.Play();

    }

    [SerializeField] GameObject cuttingBoard;
    [SerializeField] GameObject mixingBowl;


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
        recipeNext.SetActive(true);

        //recipe page opens + its contents show with it dynamically (HMM) 
        recipePage.SetActive(true);
        recipeTitle.SetActive(true);
        recipeContent1.SetActive(true);
        //recipe page must hold values that are set true or false depending on whether/ how they are toggled in VN gameplay 0
    }

    public void closeRecipe()
    {
        recipeButton.SetActive(true);
        //settingsButton.SetActive(true);

        //recipe page closes
        recipePage.SetActive(false);
        recipeTitle.SetActive(false);
        recipeContent1.SetActive(false);
        recipeContent2.SetActive(false);

        exitButton.SetActive(false);
        recipeNext.SetActive(false);
        recipePrev.SetActive(false);
        //ensures the contents of it, closes with it

    }

    public void nextPage()
    {
        recipeButton.SetActive(false);
        //settingsButton.SetActive(true);

        //recipe page closes
        //recipePage.SetActive(false);
        recipeTitle.SetActive(false);
        recipeContent1.SetActive(false);

        recipePage.SetActive(true);
        recipeContent2.SetActive(true);

        recipeNext.SetActive(false);
        recipePrev.SetActive(true);
        exitButton.SetActive(true);
        //ensures the contents of it, closes with it

    }

    public void prevPage()
    {
        recipeButton.SetActive(false);
        //settingsButton.SetActive(true);

        recipeTitle.SetActive(true);
        recipeContent1.SetActive(true);

        recipePage.SetActive(true);
        recipeContent2.SetActive(false);

        recipeNext.SetActive(true);
        recipePrev.SetActive(false);
        exitButton.SetActive(true);
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
                break;
            case "mixing bowl":
                mixingBowl.SetActive(true);
                break;
            case "saucepan":
                break;
        }

        self.SetActive(false);
    }

    public void startGame(Object nextScene)
    {
        //menuSelect.Play();
        //temp name
        //SceneManager.LoadScene("PreHaloHalo");
        StartCoroutine(DelaySceneLoad("PreHaloHalo"));
    }

    public void quitGame()
    {
        Application.Quit(); //use this for when actually deploying game
        //UnityEditor.EditorApplication.isPlaying = false; //this is temporary, just for editor purposes
    }

    IEnumerator DelaySceneLoad(string scene)
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(scene);
    }
}
