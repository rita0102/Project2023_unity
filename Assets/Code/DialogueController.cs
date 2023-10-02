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

        //按下F?，?前行文本完成就?行?程，?前行文本未完成就直接?示?前行文本
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

        //判?文本文件里的?容
        /*switch (textList[index].Trim())
        {
            case "主角":
                characterImage.sprite = headPlayer;
                index++;
                break;
            case "B":
                headImage.sprite = headNPC;
                index++;
                break;
        }*/

        //每按一次F?播放一行文字
        int word = 0;
        while (isTyping && word < textList[index].Length - 1)
        {
            dialogueText.text += textList[index][word];
            word++;
            yield return new WaitForSeconds(textSpeed);
        }
        //快速?示文本?容?本行?容
        dialogueText.text = textList[index];

        isTyping = true;
        isFinish = true;
        index++;
    }
}