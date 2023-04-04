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
        bar1.SetActive(true);
    }
    public void downArrow()
    {
        //Scene currentScene = SceneManager.GetActiveScene();
        //string sceneName = currentScene.name;

        bar1.SetActive(false);
        bar2.SetActive(true);

    }
}
