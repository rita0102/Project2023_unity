using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    public TextAsset textFile;
    public Story story=null;

    
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject dialoguePanel;
    [SerializeField]
    private Text speaker;
    [SerializeField]
    private Text dialogue;
    [SerializeField]
    private GameObject choiceBox = null;
    // UI Prefabs
    [SerializeField]
    private Button buttonPrefab = null;
    // This is a super bare bones example of how to play and display a ink story in Unity.

    private string playerName;

    public static event Action<Story> OnCreateStory;

    void Awake()
    {
        canvas.SetActive(true);
        // Remove the default message
        RemoveChildren();
        StartStory();
        playerName = PlayerPrefs.GetString("playerName");
        speaker.text = "test";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            RefreshView();
            //dialogue.text = "test";
        }
    }
    // Creates a new Story object with the compiled story which we can then play!
    void StartStory()
    {
        story = new Story(textFile.text);
        if (OnCreateStory != null) OnCreateStory(story);
        RefreshView();
    }

    // This is the main function called every time the story changes. It does a few things:
    // Destroys all the old content and choices.
    // Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
    void RefreshView()
    {
        // Remove all the UI on screen
        RemoveChildren();

        // Read all the content until we can't continue any more
        if (story.canContinue)
        {
            // Continue gets the next line of the story
            string text = story.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            dialogue.text=text;
            // Display the text on screen!
            //CreateContentView(text);
        }

        // Display all the choices, if there are any!
        else if (story.currentChoices.Count > 0)
        {
            choiceBox.SetActive(true);
            speaker.text = playerName;
            dialogue.text = "";
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate {
                    OnClickChoiceButton(choice);
                });
            }
        }
        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            canvas.SetActive(false);
            //dialogue.text = "END";
        }
    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    // Creates a textbox showing the the line of text
    /* void CreateContentView(string text)
    {
        Text storyText = Instantiate(dialogue) as Text;
        storyText.text = text;
        storyText.transform.SetParent(canvas.transform, false);
    }*/

    // Creates a button showing the choice text
    Button CreateChoiceView(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(choiceBox.transform, false);

        // Gets the text from the button prefab
        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;

        // Make the button expand to fit the text
        VerticalLayoutGroup layoutGroup = choice.GetComponent<VerticalLayoutGroup>();
        layoutGroup.childForceExpandHeight = false;

        return choice;
    }

    // Destroys all the children of this gameobject (all the UI)
    void RemoveChildren()
    {
        int childCount = choiceBox.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            Destroy(choiceBox.transform.GetChild(i).gameObject);
        }
        choiceBox.SetActive(false);
    }
}