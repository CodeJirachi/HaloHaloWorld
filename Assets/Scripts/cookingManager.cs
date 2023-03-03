using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cookingManager : MonoBehaviour
{
    //serialize game obj for each input of ingred. in glass
    [SerializeField] GameObject glassEmpty;
    [SerializeField] GameObject ice;
    [SerializeField] GameObject beans;
    [SerializeField] GameObject nataDeCoco;
    [SerializeField] GameObject lecheFlan;
    [SerializeField] GameObject stickoComplete;
   

    public void setHaloHaloSequence()
    {
        
        // track current ingred (what it is) -> 
        //if (currentIngredient.name is inventoryBeans)
        //{
            //ice.setActive(true);
            //beans.SetActive(true);
        //}
    }
    /** void initializeHaloHalo()
    {
        glassEmpty.setActive(true);
        ice.setActive(false);
        beans.setActive(false);
        natadeCoco.setActive(false);
        lecheFlan.setActive(false);
        stickoComplete.setActive(false);
    }
     **/
}
