using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    public GameObject knife;

    public GameObject chili;
    private int chiliStage;

    public void Start()
    {
        chiliStage = 0;
    }

    public void SelectTool(string name)
    {
        switch(name)
        {
            case "knife":
                knife.SetActive(!knife.activeSelf);
                break;
            case "spoon":
                knife.SetActive(false);
                break;
        }
    }

    public void Chop()
    {
        if(knife.activeSelf && chiliStage < 4)
        {
            chili.transform.GetChild(chiliStage).gameObject.SetActive(false);
            chiliStage++;
            chili.transform.GetChild(chiliStage).gameObject.SetActive(true);
        }
    }
}
