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
    //public Text LogText;

    [Header("File")]
    public TextAsset textFile;
    public int index;
    public int a = 1;

    public LogController logC;      //logC.logindex
    public int logindex = 0;       //´ú¸Õ¥Î

    bool finish;
    public List<string> textList = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        
    }
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
           // logC.logindex++;
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
           // logC.logindex++;
        }

        PlayerPrefs.SetInt("logindex", logindex);
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
        logindex++;
         finish = true;
    }

    public void auto()
    {
        a = a+1;
    }
    
}