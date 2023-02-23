using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://answers.unity.com/questions/323195/how-can-i-have-a-static-class-i-can-access-from-an.html

public class ChoiceTracker : MonoBehaviour
{
    public static ChoiceTracker CT;

    public int testVar;

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
