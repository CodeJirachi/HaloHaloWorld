using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

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

    void Start()
    {
        story = new Story(inkFile.text);
        speakerName = nameText.GetComponent<TMPro.TextMeshProUGUI>();
        message = dialogueText.GetComponent<TMPro.TextMeshProUGUI>();
        Debug.Log(speakerName.text);
        Debug.Log(message.text);
        cousinSpriteChange("neutral");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(story.canContinue)
            {
                speakerName.text = "Jayce";
                AdvanceDialogue();
            }
            else
            {
                FinishDialogue();
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
}
