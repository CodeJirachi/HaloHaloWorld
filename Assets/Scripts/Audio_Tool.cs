using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Audio_Tool : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource Hover;
    public AudioSource selectSpoon;
    public AudioSource selectKnife;
    public AudioSource knifeCut;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hover.Play();

    }
    public void spoonSelectClick()
    {
        selectSpoon.Play();
    }
    public void knifeSelectClick()
    {
        selectKnife.Play();
    }
    public void knifeCutButton()
    {
        knifeCut.Play();
    }
}
