using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    public GameObject tool;
    //tools: 
    public GameObject knife;
    public GameObject spoon;

    public GameObject collander; 
    public GameObject pot;
    public GameObject pan;
    public GameObject saucepan;
    public GameObject measuringCup;

    //affected by tool Item not needed in kitchen manager
    
    private int ingredientStage;

    public void Start()
    {
        ingredientStage = 0;
    }

    public void SelectTool(string name)
    {
        switch(name)
        {
            case "knife":
                tool.SetActive(!tool.activeSelf);
                break;
            case "spoon":
                tool.SetActive(false);
                break;
            case "pot":
                tool.SetActive(!tool.activeSelf);
                break;
        }
    }

    public void Chop()
    {
        //EXTREMELY HACK-Y WAY
        //does not need to be chili - need to generalize these variables b/c you can pick what is the "ingredient" in inspector
        
        //if(knife.activeSelf && chiliStage < 5)
        //{
        //    chili.transform.GetChild(chiliStage).gameObject.SetActive(false);
        //    chiliStage++;
        //    chili.transform.GetChild(chiliStage).gameObject.SetActive(true);
        //    if(chiliStage == 5)
        //    {
        //        //this deletes the button on top of the ingredient icon
        //        chili.transform.GetChild(6).gameObject.SetActive(false);
         //   }
        //}
    }
    public void Fill()
    {
        // JIRA!!!! fix so parts of pot dont disappear 
        //if (tool.activeSelf && ingredientStage < 3)
        //{
        //    chili.transform.
       //     chili.transform.GetChild(chiliStage).gameObject.SetActive(false);
        //    chiliStage++;
        //    chili.transform.GetChild(chiliStage).gameObject.SetActive(true);
       // }
    }
}
