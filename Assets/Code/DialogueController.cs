using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour{
    [Header("UI")]
    public Text characterName;
    public Text dialogueText;
    public Button TextAuto;

    [Header("File")]
    public TextAsset textFile;
    public int index;

    bool finish;
    int a = 0;

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
        if (a%2 == 0)
        {
            if (Input.GetButtonDown("Auto"))
            {

            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && finish == true)
        {
            if(index < textList.Count) {
                characterName.text = textList[index];
                index++;
                //dialogueText.text = textList[index];
                //index++;
                StartCoroutine(SetTextUI());
                
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

    IEnumerator SetTextUI()
    {
        finish = false;
        dialogueText.text = "";
        for (int i = 0; i < textList[index].Length; i++)
        {
            dialogueText.text += textList[index][i];

            yield return new WaitForSeconds(0.1f);
        }


        finish = true;
        index++;
    }

    public void auto()
    {
        a = a++;
    }
}