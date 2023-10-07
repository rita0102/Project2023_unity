using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class LogController : MonoBehaviour
{

    public DialogSystem dialog;

    public Text LogText;
    public TextAsset textFile;
    public int logindex = 0;

    //代刚
    

    // Start is called before the first frame update
    void Start()
    {
        logindex = PlayerPrefs.GetInt("logindex");

        LogText.text = "";
        //LogText.text += logindex + "\n";              //代刚ノ
       // LogText.text += dialog.textList[0] + "\n";     //代刚ノ
       // LogText.text += dialog.textList[1] + "\n";     //代刚ノ
       // LogText.text += dialog.textList[2] + "\n";     //代刚ノ


        for (int i = 0; i < logindex; i++)
        {
            LogText.text += dialog.textList[i] + "\n";
        }
    }

    /*
    void Awake()
    {
        dialog.getTextFromFile(textFile);
    }
    */
    // Update is called once per frame
    void Update()
    {
        
    }

}
