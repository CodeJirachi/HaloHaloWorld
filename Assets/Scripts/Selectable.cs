using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    //credit: https://github.com/RisingArtist/Ink-with-Unity-2019.3

    public object element;
    public void Decide()
    {
        DialogueManager.SetDecision(element);
    }

}
