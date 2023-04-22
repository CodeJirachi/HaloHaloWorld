using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio_DoNotDestroyFINAL : MonoBehaviour
{
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string scene_name = currentScene.name;

        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("FinalMusic");

        if (musicObject.Length > 1)
        {
            Destroy(this.gameObject);
            //DontDestroyOnLoad(this.gameObject);
            Debug.Log(scene_name);
        }

        //Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
        Debug.Log(scene_name);

    }
}