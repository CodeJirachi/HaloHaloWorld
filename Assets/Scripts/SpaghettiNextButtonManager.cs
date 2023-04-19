using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaghettiNextButtonManager : MonoBehaviour
{
    public GameObject cuttingBoard;
    public GameObject stovetop;
    public GameObject plating;
    public GameObject complete;

    public GameObject nextStageButton1;
    public GameObject nextStageButton2;
    //public GameObject nextStageButton3;

    // scene starts this way
    /*
    public void spaghettiCutting()
    {
        cuttingBoard.SetActive(true);

    }
     * */

    // 
    /*
    public void spaghettiCooking()
    {
        cuttingBoard.SetActive(false);

        stovetop.SetActive(true);
        plating.SetActive(false);

        nextStageButton1.SetActive(false);
        nextStageButton2.SetActive(true);
    }
     * */

    // 1
    public void spaghettiPlating()
    {
        cuttingBoard.SetActive(false);
        stovetop.SetActive(true);
        plating.SetActive(true);

        nextStageButton1.SetActive(false);
        nextStageButton2.SetActive(true);
    }

    // 2
    public void spaghettiCompletion()
    {
        cuttingBoard.SetActive(false);
        stovetop.SetActive(false);
        plating.SetActive(false);

        complete.SetActive(true);

        nextStageButton2.SetActive(false);
    }
}
