using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour{
    [Header("")]
    public Text characterName;
    public Text dialogueText;

    [Header("File")]
    public TextAsset textFile;
    public int index;

    List<string> textList = new List<string>();


    void Awake()
    {
        getTextFromFile(textFile);
    }
    void OnEnable()
    {
        characterName.text = textList[index];
        index++;
        dialogueText.text = textList[index];
        index++;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(index < textList.Count) {
                characterName.text = textList[index];
                index++;
                dialogueText.text = textList[index];
                index++;
                
            }
            else
            {
                characterName.text = dialogueText.text = "";
                index = 0;
            }
        }
    }
    void getTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var LineData = file.text.Split('\n');
        foreach (var line in LineData) {
            textList.Add(line);
        }
    }
}