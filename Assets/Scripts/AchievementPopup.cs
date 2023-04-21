using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementPopup : MonoBehaviour
{
    //goal is get to negative -191, then disappear

    void Start()
    {
        StartCoroutine(PopUp());
    }

    void Update()
    {
        if (this.gameObject.GetComponent<RectTransform>().anchoredPosition.y >= -191)
        {
            StartCoroutine(GoDown());
        }
    }

    IEnumerator PopUp(int speed = 50)
    {
        float offset;

        while(this.gameObject.GetComponent<RectTransform>().anchoredPosition.y <= -191)
        {
            offset = this.gameObject.GetComponent<RectTransform>().anchoredPosition.y + (speed * Time.deltaTime);

            this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.gameObject.GetComponent<RectTransform>().anchoredPosition.x, offset);

            yield return null;
        }
        
    }

     IEnumerator GoDown(int speed = 1)
    {
        float offset;

        yield return new WaitForSeconds(5.0f);

        while (this.gameObject.GetComponent<RectTransform>().anchoredPosition.y >= -258)
        {
            offset = this.gameObject.GetComponent<RectTransform>().anchoredPosition.y - (speed * Time.deltaTime);

            this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.gameObject.GetComponent<RectTransform>().anchoredPosition.x, offset);

            if(this.gameObject.GetComponent<RectTransform>().anchoredPosition.y <= -258)
            {
                this.gameObject.SetActive(false);
            }

            yield return null;
        }
    }

}
