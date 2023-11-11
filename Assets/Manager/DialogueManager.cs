using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System.Threading;
using System.Reflection;
using Unity.Collections;


public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    public TextAsset textFile;
    [SerializeField]
    private GameObject dialogueSystem;
    [SerializeField]
    private GameObject dialoguePanel;
    [SerializeField]
    private Text speaker;
    [SerializeField]
    private Text dialogue;
    [SerializeField]
    private GameObject choiceBox;
    [SerializeField]
    private Button[] choiceButton;

    private Story story = null;

    // This is a super bare bones example of how to play and display a ink story in Unity.

    public bool auto;
    private string playerName;
    string dialogueText;
    private bool sentencefisish;

    public static event Action<Story> OnCreateStory;

    private void Awake()
    {
        //playerName= PlayerPrefs.GetString("playerName");
        playerName = "AAA";
        RemoveChoice();
        story = new Story(textFile.text);
        if (OnCreateStory != null) OnCreateStory(story);
        RefreshView();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && auto==false && sentencefisish==true)
        {
            RefreshView();
        }
        else if (auto == true && sentencefisish==true)
        {
            Thread.Sleep(1000);
            RefreshView();
        }

    }

    void RefreshView()
    {
        // Remove all the choice on screen
        RemoveChoice();
        //initialize
        dialogue.fontSize = 32;
        // Read all the content until we can't continue any more
        if (story.canContinue)
        {
            // Continue gets the next line of the story
            dialogueText = story.Continue();
            // This removes any white space from the text.
            dialogueText = dialogueText.Trim();
            // Display the text on screen!
            StartCoroutine(SetTextUI());
            HandleTags(story.currentTags);
        }

        // Display all the choices, if there are any!
        else if (story.currentChoices.Count > 0)
        {
            SetChoice();
        }
        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            dialogueSystem.SetActive(false);
        }
    }

    private void SetChoice()
    {
        choiceBox.SetActive(true);
        speaker.text = playerName;
        dialogue.text = "";
        for (int i=0;i< story.currentChoices.Count; i++)
        {
            choiceButton[i].gameObject.SetActive(true);
            choiceButton[i].GetComponentInChildren<Text>().text = story.currentChoices[i].text;
        }
    }

    public void MakeChoice(int index)
    {
        story.ChooseChoiceIndex(index);
        story.Continue();
        RefreshView();
    }

    void RemoveChoice()
    {
        choiceBox.SetActive(false);
        for (int i=0;i< choiceButton.Length; i++)
        {
            choiceButton[i].gameObject.SetActive(false);
        }
    }

    private void HandleTags(List<string> tags)
    {
        foreach(string tag in tags)
        {
            string[] splitTag = tag.Split(':');
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case "speaker":
                    if (string.Compare(tagValue, "A") == 0)
                    {
                        speaker.text = playerName;
                    }
                    else
                    {
                        speaker.text = tagValue;
                    }
                    break;
                case "expression":
                    break;
                case "size":
                    dialogue.fontSize= int.Parse(tagValue);
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator SetTextUI()
    {
        sentencefisish = false;
        dialogue.text = "";
        for (int i = 0; i < dialogueText.Length; i++)
        {
            dialogue.text += dialogueText[i];

            yield return new WaitForSeconds(0.1f);
        }
        sentencefisish = true;
    }

    public void Auto()
    {
        auto = !auto;
    }

}    