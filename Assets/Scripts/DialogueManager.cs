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
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(story.canContinue)
            {
                speakerName.text = "Jayce";
                AdvanceDialogue();
            }
        }
        else
        {
            //infinitely says the logged msg
            FinishDialogue();
        }
    }

    void AdvanceDialogue()
    {
        string currentSentence = story.Continue();
        message.text = currentSentence;
    }

    void FinishDialogue()
    {
        //in game, change scene to minigame
        Debug.Log("yahoo finished");
    }
}
