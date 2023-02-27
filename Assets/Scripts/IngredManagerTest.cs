using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredManagerTest : MonoBehaviour
{

    [SerializeField] GameObject beans;
    [SerializeField] GameObject beansGlass;
    // Start is called before the first frame update
    public void insertBeans()
    {
        beansGlass.SetActive(true);
    }

}
