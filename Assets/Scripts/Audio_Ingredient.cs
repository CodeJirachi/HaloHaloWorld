using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Audio_Ingredient : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public AudioSource Select;
    public AudioSource Hover;

    // Halo Halo Only (Spoon scooping into glass)
    public AudioSource Scoop;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Hover.Play();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       Select.Play();
    }

    public void OnDrag(PointerEventData eventData)
    {
 
    }

    
    public void OnEndDrag(PointerEventData eventData)
    {
        // this won't work b/c it disappears before sound comes thru
        //Scoop.Play();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void uiClick(){
        Select.Play();
    }
}
