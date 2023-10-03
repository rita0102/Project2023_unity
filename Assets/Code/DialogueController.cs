using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class DialogSystem : MonoBehaviour{
    [Header("UI")]
    public Text characterName;
    public Text dialogueText;

    [Header("File")]
    public TextAsset textFile;
    public int index;
    public int a = 1;

    bool finish;
    List<string> textList = new List<string>();


    void Awake()
    {
        getTextFromFile(textFile);
    }
    void OnEnable()
    {
        characterName.text = textList[index];
        index++;
        StartCoroutine(SetTextUI());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && finish == true && a%2 == 0)
        {
            if (index < textList.Count)
            {
                characterName.text = textList[index];
                index++;
                //dialogueText.text = textList[index];
                //index++;
                StartCoroutine(SetTextUI());
            }
        }
        else if(finish == true && a % 2 == 1)
        {
            if(index< textList.Count) {
                Thread.Sleep(1000);
                characterName.text = textList[index];
                index++;
                //dialogueText.text = textList[index];
                //index++;
                StartCoroutine(SetTextUI());
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

    IEnumerator SetTextUI()
    {
        finish = false;
        dialogueText.text = "";
        for (int i = 0; i < textList[index].Length; i++)
        {
            dialogueText.text += textList[index][i];

            yield return new WaitForSeconds(0.1f);
        }
        index++;
        finish = true;
    }

    public void auto()
    {
        a = a+1;
    }
}