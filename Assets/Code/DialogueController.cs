using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using Unity.VisualScripting;

public class DialogSystem : MonoBehaviour{
    [Header("UI")]
    public Text characterName;
    public Text dialogueText;
    //public Text LogText;

    [Header("File")]
    public TextAsset textFile;
    public int index;
    public bool a = false;

    

    // public LogController logC;      //logC.logindex
    public int logIndex = 0;

    bool finish;
    public List<string> textList = new List<string>();

    public string playerName;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        getTextFromFile(textFile);
        playerName = PlayerPrefs.GetString("playerName");
    }
    void OnEnable()
    {
        if (string.Compare(textList[index], "еDид")==1)
        {
            characterName.text = playerName;
        }
        else
        {
            characterName.text = textList[index];
        }
        index++;
        StartCoroutine(SetTextUI());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && finish == true && a)
        {

            if (index < textList.Count)
            {
                if (string.Compare(textList[index], "еDид") == 1)
                {
                    characterName.text = playerName;
                }
                else
                {
                    characterName.text = textList[index];
                }
                index++;

                //dialogueText.text = textList[index];
                //index++;
                StartCoroutine(SetTextUI());
            }
           // logC.logindex++;
        }
        else if(finish == true && !a)
        {
            if(index< textList.Count) {
                Thread.Sleep(1000);
                if (string.Compare(textList[index], "еDид") == 1)
                {
                    characterName.text = playerName;
                }
                else
                {
                    characterName.text = textList[index];
                }
                index++;

                //dialogueText.text = textList[index];
                //index++;
                StartCoroutine(SetTextUI());
            }
           // logC.logindex++;
        }

       PlayerPrefs.SetInt("logindex", logIndex);
       // LogText.text += textList[logindex] + "\n";
    }

    public void getTextFromFile(TextAsset file)
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

        // logC.logindex++;
        logIndex++;
         finish = true;
    }

    public void Auto()
    {
        a = !a;
    }
    
}