using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    //adapted from https://turbofuture.com/graphic-design-video/How-to-Fade-to-Black-in-Unity - thank you

    public bool fadeIn;
    public bool fadeOut;
    GameObject blackSquare;

    // Start is called before the first frame update
    void Start()
    {
        fadeIn = false;
        fadeOut = false;
        blackSquare = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeIn)
        {
            StartCoroutine(Fade(true));
        } else if(fadeOut)
        {
            StartCoroutine(Fade(false));
        }
    }

    IEnumerator Fade(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        Color objColor = blackSquare.GetComponent<SpriteRenderer>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (blackSquare.GetComponent<SpriteRenderer>().color.a < 1)
            {
                fadeAmount = objColor.a + (fadeSpeed * Time.deltaTime);

                objColor = new Color(objColor.r, objColor.g, objColor.b, fadeAmount);
                blackSquare.GetComponent<SpriteRenderer>().color = objColor;
                yield return null;
            }
        } else
        {
            while (blackSquare.GetComponent<SpriteRenderer>().color.a > 0)
            {
                fadeAmount = objColor.a - (fadeSpeed * Time.deltaTime);

                objColor = new Color(objColor.r, objColor.g, objColor.b, fadeAmount);
                blackSquare.GetComponent<SpriteRenderer>().color = objColor;
                yield return null;
            }
        }
    }
}
