using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System.Reflection;
using System.Threading;
using Unity.VisualScripting;

public class BookManager : MonoBehaviour
{
    [SerializeField]
    public TextAsset textFile;
    [SerializeField]
    private GameObject dialogueSystem;
    [SerializeField]
    private GameObject dialoguePanel;
    [SerializeField]
    private Text bookText;
    [SerializeField]
    private Button[] choiceButton;

    private Story story = null;

    // This is a super bare bones example of how to play and display a ink story in Unity.

    string fileText;

    public static event Action<Story> OnCreateStory;

    private void Awake()
    {
        story = new Story(textFile.text);
        if (OnCreateStory != null) OnCreateStory(story);
        RefreshView();
    }

    void RefreshView()
    {
        bookText.text = "";
        RemoveChoice();
        // Read all the content until we can't continue any more
        
            while (story.canContinue)
            {
                // Continue gets the next line of the story
                fileText = story.Continue();
                // This removes any white space from the text.
                // Display the text on screen!
                bookText.text = bookText.text + fileText;
            }
        
        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
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
        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            choiceButton[i].gameObject.SetActive(true);
            choiceButton[i].GetComponentInChildren<Text>().text = story.currentChoices[i].text;
        }
    }

    void RemoveChoice()
    {
        for (int i = 0; i < choiceButton.Length; i++)
        {
            choiceButton[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int index)
    {
        story.ChooseChoiceIndex(index);
        RefreshView();
    }
}
