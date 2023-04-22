using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavManager : MonoBehaviour
{

    public void goToMainMenu()
    {
        StartCoroutine(LoadSceneAfterSeconds(3.0f, "MainMenu"));
    }

    public void goToHaloHalo()
    {
        // VN before Halo Halo
        StartCoroutine(LoadSceneAfterSeconds(3.0f, "PreHaloHalo"));
    }

    public void goToSpaghetti()
    {
        StartCoroutine(LoadSceneAfterSeconds(3.0f, "PreSpaghetti"));
    }

    public void goToBibingka()
    {
        StartCoroutine(LoadSceneAfterSeconds(3.0f, "VN_PreBibingka"));
    }

    public void goToFinalRecipe()
    {
        StartCoroutine(LoadSceneAfterSeconds(3.0f, "VN_PreFusion"));
    }

    public void goToEnding()
    {
        StartCoroutine(LoadSceneAfterSeconds(3.0f, "VN_Final1"));
    }

    IEnumerator LoadSceneAfterSeconds(float seconds, string scene_name)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(scene_name);
    }

}
