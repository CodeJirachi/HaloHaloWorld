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
        //EXTREMELY HACK-Y WAY
        //does not need to be chili - need to generalize these variables b/c you can pick what is the "ingredient" in inspector
        if(knife.activeSelf && chiliStage < 5)
        {
            chili.transform.GetChild(chiliStage).gameObject.SetActive(false);
            chiliStage++;
            chili.transform.GetChild(chiliStage).gameObject.SetActive(true);
            if(chiliStage == 5)
            {
                //this deletes the button on top of the ingredient icon
                chili.transform.GetChild(6).gameObject.SetActive(false);
            }
        }
    }
}
