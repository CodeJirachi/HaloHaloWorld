using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingTrigger : MonoBehaviour
{
    //POSITIONS TO SPAWN STAR TRIGGERS:
    // (0,70) ; (-100, -20) ; (0, -140) ; (115, -20)

    public GameObject mixingTrigger;
    public Canvas canvas;
    public GameObject mixer; //this is the object to be mixed/change stages of

    GameObject newTrigger;
    Vector2 spawnPos;

    public KitchenManager KM;

    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0))
        {
            if (KM.mixingTriggerStage > 10) KM.mixingTriggerStage = 0;
            //Debug.Log("yoo");
            switch (KM.mixingTriggerStage / 3) //??? why does it skip certain numbers that i have to divide by 3
            {
                case 0:
                    spawnPos = new Vector2(0, 70);
                    break;
                case 1:
                    spawnPos = new Vector2(-100, -20);
                    break;
                case 2:
                    spawnPos = new Vector2(0, -140);
                    break;
                case 3:
                    spawnPos = new Vector2(115, -20);
                    mixer.transform.GetChild(KM.mixingStage / 2).gameObject.SetActive(false);
                    KM.mixingStage++;
                    break;
            }

            mixer.transform.GetChild(KM.mixingStage / 2).gameObject.SetActive(true);

            if (KM.mixingStage < 7)
            {
                newTrigger = Instantiate(mixingTrigger, canvas.transform);
                newTrigger.GetComponent<RectTransform>().anchoredPosition = spawnPos;
                newTrigger.GetComponent<RectTransform>().rotation = Quaternion.Euler(0f, 0f, 90.0f * (KM.mixingTriggerStage / 3));
            }

            Destroy(this.gameObject);
            KM.mixingTriggerStage++;
        }
    }
}
