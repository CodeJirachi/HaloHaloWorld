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

    public GameObject nameBox;

    public GameObject jasmine;
    public GameObject jayce;

    static Story story;
    TextMeshProUGUI speakerName;
    TextMeshProUGUI message;

    public GameObject choicePanel;
    public GameObject customButton;
    static Choice choiceSelected;

    List<string> tags;

    public bool inChoices;

    void Start()
    {
        story = new Story(inkFile.text);
        speakerName = nameText.GetComponent<TMPro.TextMeshProUGUI>();
        message = dialogueText.GetComponent<TMPro.TextMeshProUGUI>();
        //Debug.Log(speakerName.text);
        //Debug.Log(message.text);

        //might need to hardcode first line of scene:
        //speakerName.text = "";
        //message.text = "--ACT 1 BEGIN--";
        AdvanceDialogue();

        inChoices = false;

        if(speakerName.text == "")
        {
            nameBox.SetActive(false);
        } else
        {
            nameBox.SetActive(true);
        }

        //testing things - to be deleted/changed
        //cousinSpriteChange("neutral");
        //ChoiceTracker.CT.testVar = 3;
        //Debug.Log(ChoiceTracker.CT.testVar);
    }

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) && !inChoices) 
        {
            if(story.canContinue)
            {
                AdvanceDialogue();

                if(story.currentChoices.Count > 0)
                {
                    //Debug.Log("choices...");
                    StartCoroutine(ShowChoices());
                }
            }
            else
            {
                //FinishDialogue();
                ChoiceTracker.CT.scene += 1;
                switch(ChoiceTracker.CT.scene)
                {
                    case 1:
                        //SceneManager.LoadScene("HaloHalo 1");
                        SceneManager.LoadScene("HaloHalo Final (audrey)");
                        Debug.Log("scene is " + ChoiceTracker.CT.scene);
                        break;
                    case 2:
                        //spaghetti
                        //SceneManager.LoadScene("Spaghetti 1");
                        SceneManager.LoadScene("Spaghetti 1(COPY) (JIRA)");
                        Debug.Log("scene is " + ChoiceTracker.CT.scene);
                        break;
                }
            }
        }
    }

    void AdvanceDialogue()
    {
        string currentSentence = story.Continue();
        message.text = currentSentence;
        ParseTags();
        StopAllCoroutines();
    }

    void FinishDialogue()
    {
        //in game, change scene to minigame
        Debug.Log("yahoo finished");
    }
    
    IEnumerator ShowChoices()
    {
        inChoices = true;
        Debug.Log("choices appear");
        List<Choice> choices = story.currentChoices;

        for(int i = 0; i < choices.Count; i++)
        {
            //create temp button for each choice
            Debug.Log(i + ": " + choices[i].text);

            //hack-y way to spawn buttons for now, need offset bc of choice canvas (WHEN CHOICE CANVAS RENDER MODE IS SET TO OVERLAY)
            //GameObject temp = Instantiate(customButton, new Vector3(347.5f, (i*40)+195.4f, 0), Quaternion.identity, choicePanel.transform);
            GameObject temp = Instantiate(customButton, new Vector3(0, (i * 1), 0), Quaternion.identity, choicePanel.transform); //for when render mode = world space

            temp.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = choices[i].text;
            temp.AddComponent<Selectable>();
            temp.GetComponent<Selectable>().element = choices[i];
            temp.GetComponent<Button>().onClick.AddListener(() => { temp.GetComponent<Selectable>().Decide(); });
        }

        choicePanel.SetActive(true);

        yield return new WaitUntil(() => { return choiceSelected != null; });

        AdvanceFromDecision();
    }

    void AdvanceFromDecision()
    {
        choicePanel.SetActive(false);
        for (int i = 0; i < choicePanel.transform.childCount; i++)
        {
            Destroy(choicePanel.transform.GetChild(i).gameObject);
        }
        choiceSelected = null; // Forgot to reset the choiceSelected. Otherwise, it would select an option without player intervention.
        inChoices = false;
        AdvanceDialogue();
    }

    public static void SetDecision(object element)
    {
        Choice choice = (Choice)element;

        //set selected choice to its TEXT in order to keep between scenes
        ChoiceTracker.CT.choice = choice.text;
        choiceSelected = choice;
        story.ChooseChoiceIndex(choiceSelected.index);
    }

    void ParseTags()
    {
        tags = story.currentTags;
        foreach (string t in tags)
        {
            string prefix = t.Split(' ')[0];
            string param = t.Split(' ')[1];
            //string param2 = t.Split(' ')[2];

            switch (prefix.ToLower())
            {
                //need better system for sprite changing
                case "cousin":
                    cousinSpriteChange(param);
                    break;
                case "speaker":
                    changeSpeaker(param);
                    break;
                case "jayce":
                    jayceSpriteChange(param);
                    break;
            }
        }
    }

    //better system needed
    //maybe separate SpriteManager script?
    void cousinSpriteChange(string expression)
    {
        foreach (Transform child in jasmine.transform)
        {
            child.gameObject.SetActive(false);
        }

        switch (expression)
        {
            case "neutral":
                jasmine.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "annoyed":
                jasmine.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case "worried":
                jasmine.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case "happy":
                jasmine.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case "none":
                break;
            default:
                break;
        }
    }

    void jayceSpriteChange(string expression)
    {
        foreach(Transform child in jayce.transform)
        {
            child.gameObject.SetActive(false);
        }

        switch (expression)
        {
            case "neutral":
                jayce.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "excited":
                jayce.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case "sad":
                jayce.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case "wink":
                jayce.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case "annoyed":
                jayce.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case "shocked":
                jayce.transform.GetChild(5).gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    void changeSpeaker(string name)
    {
        if(name == "clear")
        {
            speakerName.text = "";
        } else
        {
            nameBox.SetActive(true);
            speakerName.text = name;
        }

        //disable text box when no name
        if(speakerName.text == "")
        {
            nameBox.SetActive(false);
        }
    }

    //function TBA - fast forward for VN
    //coroutine - play each line, waitsomethingseconds, stop when faced with choice
}

