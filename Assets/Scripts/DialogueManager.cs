using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.SceneManagement;

//VISUAL NOVEL/INK INTEGRATION CODE ADAPTED FROM:
//https://www.youtube.com/watch?v=-nK-tQ_vc0Y 
//The Phantom Game Designs

public class DialogueManager : MonoBehaviour
{
    public TextAsset inkFile;
    public GameObject dialogueText;
    public GameObject nameText;

    //is there a better way to do this lol
    public GameObject cousinNeutral;
    public GameObject cousinAnnoyed;
    public GameObject cousinWorried;
    public GameObject cousinHappy;

    static Story story;
    TextMeshProUGUI speakerName;
    TextMeshProUGUI message;

    public GameObject customButton;

    void Start()
    {
        story = new Story(inkFile.text);
        speakerName = nameText.GetComponent<TMPro.TextMeshProUGUI>();
        message = dialogueText.GetComponent<TMPro.TextMeshProUGUI>();
        Debug.Log(speakerName.text);
        Debug.Log(message.text);
        cousinSpriteChange("neutral");
        ChoiceTracker.CT.testVar = 3;
        Debug.Log(ChoiceTracker.CT.testVar);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(story.canContinue)
            {
                speakerName.text = "Jayce";
                AdvanceDialogue();

                if(story.currentChoices.Count > 0)
                {
                    Debug.Log("choices...");
                }
            }
            else
            {
                //FinishDialogue();
                SceneManager.LoadScene("UI testing");
            }
        }
    }

    void AdvanceDialogue()
    {
        string currentSentence = story.Continue();
        message.text = currentSentence;
        cousinSpriteChange("happy");
    }

    void FinishDialogue()
    {
        //in game, change scene to minigame
        Debug.Log("yahoo finished");
    }

    void cousinSpriteChange(string expression)
    {
        switch(expression)
        {
            case "neutral":
                cousinNeutral.SetActive(true);
                cousinAnnoyed.SetActive(false);
                cousinWorried.SetActive(false);
                cousinHappy.SetActive(false);
                break;
            case "happy":
                cousinNeutral.SetActive(false);
                cousinAnnoyed.SetActive(false);
                cousinWorried.SetActive(false);
                cousinHappy.SetActive(true);
                break;
            case "annoyed":
                cousinNeutral.SetActive(false);
                cousinAnnoyed.SetActive(true);
                cousinWorried.SetActive(false);
                cousinHappy.SetActive(false);
                break;
            case "worried":
                cousinNeutral.SetActive(false);
                cousinAnnoyed.SetActive(false);
                cousinWorried.SetActive(true);
                cousinHappy.SetActive(false);
                break;
        }
    }

    /*
    IENumerator ShowChoices()
    {
        Debug.Log("choices appear");
        List<Choice> choices = story.currentChoices;

        foreach (Choice choice in choices)
        {
            //FINISH THIS
            //create temp button for each choice
            GameObject temp = Instantiate(customButton);
            temp.transform.GetChild(0).GetComponent<Text>().text = choice.text;
            temp.AddComponent<Selectable>();
        }
    
    }
    */
    
}

