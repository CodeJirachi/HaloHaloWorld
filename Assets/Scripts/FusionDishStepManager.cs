using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FusionDishStepManager : MonoBehaviour
{
    public static FusionDishStepManager FSM; //for accessing this class's variables

    public int step;
    public Canvas canvas;

    public GameObject nextButtonPrefab;
    GameObject nextButton;


    string scene_name;
    bool stepFinished; //for end condition of scene

    void Start()
    {
        scene_name = SceneManager.GetActiveScene().name;
        step = 0;
        stepFinished = false;
    }

    void Update()
    {
        if(scene_name == "FusionDish (NEW)")
        {
            //end condition
            if (!stepFinished && GameObject.Find("cooked rice") != null && GameObject.Find("cooked rice").activeSelf && GameObject.Find("cooked rice").GetComponent<IngredientDragDrop>().inSlot)
            { 
                stepFinished = true;

                //spawn next button
                nextButton = Instantiate(nextButtonPrefab, canvas.transform);
                nextButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(348, 0);
                nextButton.GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadScene("FusionDish Boiling Lechon"); });
            }
        }
    }
}
