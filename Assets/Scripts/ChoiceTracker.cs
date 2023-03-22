using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Idea & code adapted from:
//https://answers.unity.com/questions/323195/how-can-i-have-a-static-class-i-can-access-from-an.html

public class ChoiceTracker : MonoBehaviour
{
    public static ChoiceTracker CT;

    public int testVar;
    public string choice;
    public int scene = 0; //used for checking which recipe to change to after (1 = halo halo, 2 = spaghetti, etc.)

    private void Awake()
    {
        if(CT != null)
        {
            GameObject.Destroy(CT);
        }
        else
        {
            CT = this;
        }

        DontDestroyOnLoad(this);
    }
}
