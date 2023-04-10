using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ingredientBarManager : MonoBehaviour
{
    [SerializeField] GameObject bar1;
    [SerializeField] GameObject bar2;
    
    public void Awake()
    {
        //bar1.SetActive(true);
    }
    public void downArrow()
    {
        //Scene currentScene = SceneManager.GetActiveScene();
        //string sceneName = currentScene.name;
        if (bar1.activeInHierarchy == true)
        {
            bar1.SetActive(false);
            bar2.SetActive(true);
        }
        else if (bar2.activeInHierarchy == true)
        {
            bar2.SetActive(false);
            bar1.SetActive(true);
        }

    }

    public void upArrow()
    {
        if (bar1.activeInHierarchy == true)
        {
            bar1.SetActive(false);
            bar2.SetActive(true);
        }
        else if (bar2.activeInHierarchy == true)
        {
            bar2.SetActive(false);
            bar1.SetActive(true);
        }
    }
}
