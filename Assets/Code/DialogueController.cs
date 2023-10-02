using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public Image characterImage;
    public Text dialogueText;

    public TextAsset textFile;
    public int index;
    public float textSpeed;

    public Sprite headPlayer;
    public Sprite headNPC;

    //Text
    bool isFinish;  
    bool isTyping; 

    List<string> textList = new List<string>();

    void dialogueStart()
    {
        GetTextFromFile(textFile);
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.F) && index == textList.Count)
        {
            SceneManager.LoadScene("sceneName");//
            return;
        }

        //���UF?�A?�e��奻�����N?��?�{�A?�e��奻�������N����?��?�e��奻
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isFinish)
            {
                StartCoroutine(setTextUI());
            }
            else if (!isFinish)
            {
                isTyping = false;
            }
        }
    }

    void GetTextFromFile(TextAsset file){
        textList.Clear();
        var lineDate = file.text.Split('\n');
        foreach (var line in lineDate){
            textList.Add(line);
        }
    }

    IEnumerator setTextUI()
    {
        isFinish = false;   
        dialogueText.text = ""; 

        //�P?�奻��󨽪�?�e
        /*switch (textList[index].Trim())
        {
            case "�D��":
                characterImage.sprite = headPlayer;
                index++;
                break;
            case "B":
                headImage.sprite = headNPC;
                index++;
                break;
        }*/

        //�C���@��F?����@���r
        int word = 0;
        while (isTyping && word < textList[index].Length - 1)
        {
            dialogueText.text += textList[index][word];
            word++;
            yield return new WaitForSeconds(textSpeed);
        }
        //�ֳt?�ܤ奻?�e?����?�e
        dialogueText.text = textList[index];

        isTyping = true;
        isFinish = true;
        index++;
    }
}