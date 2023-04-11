using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodContainer1 : MonoBehaviour
{
    // game objects for ingredients that goes into pot
    [SerializeField] GameObject glassEmpty;
    [SerializeField] GameObject ice;
    [SerializeField] GameObject beans;
    [SerializeField] GameObject nataDeCoco;
    [SerializeField] GameObject lecheFlan;
    [SerializeField] GameObject stickoComplete;
    // game objects for ingredients that goes into pan
    [SerializeField] GameObject glassEmpty;

    // OG state of pot and pan on stovetop 
    public GameObject potCooking;
    public GameObject panCooking;

    public string currentIngredient;
    GameObject draggedObject;

    private int currIngredientLayer;

    public void Awake()
    {
        currIngredientLayer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
