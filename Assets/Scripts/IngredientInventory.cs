using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientInventory : MonoBehaviour
{
    public int id;
    public string title;
    public string description;
    public Sprite icon;

    public Dictionary<string, int> stats = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Item(int id, string title, string description, Sprite icon, Dictionary<string,int> stats)
    {
        this.id = id;
        this.title = title;
        this.description = description; 
        this.icon = Resources.Load<
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
