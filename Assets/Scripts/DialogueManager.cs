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

    public GameObject choicePanel;
    public GameObject customButton;
    static Choice choiceSelected;

    List<string> tags;

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
        //lock advancing dialogue to space for now b/c left click breaks choices
        if(Input.GetKeyDown(KeyCode.Space)) //&& a choice isnt up? so i could leave left click in
        {
            if(story.canContinue)
            {
                //speakerName.text = "Jayce";
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
                SceneManager.LoadScene("UI testing");
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
        Debug.Log("choices appear");
        List<Choice> choices = story.currentChoices;

        for(int i = 0; i < choices.Count; i++)
        {
            //create temp button for each choice
            Debug.Log(choices[i].text);

            //hack-y way to spawn buttons for now, need offset bc of choice canvas
            GameObject temp = Instantiate(customButton, new Vector3(347.5f, (i*40)+195.4f, 0), Quaternion.identity, choicePanel.transform);
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
        AdvanceDialogue();
    }

    public static void SetDecision(object element)
    {
        Choice choice = (Choice)element;

        //Debug.Log(choice.text);

        //set selected choice in order to keep between scenes
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

            switch (prefix.ToLower())
            {
                //need better system for sprite changing
                case "cousin":
                    cousinSpriteChange(param);
                    break;
                case "speaker":
                    changeSpeaker(param);
                    break;
            }
        }
    }

    //better system needed
    void cousinSpriteChange(string expression)
    {
        switch (expression)
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

    void changeSpeaker(string name)
    {
        speakerName.text = name;
    }

    //function TBA - fast forward for VN
    //coroutine - play each line, waitsomethingseconds, stop when faced with choice
}

