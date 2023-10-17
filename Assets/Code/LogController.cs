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
    public int oldlogindex = 0;



    // Start is called before the first frame update
    void Start()
    {
        /*
        //logindex = PlayerPrefs.GetInt("logindex");

        getLogindex();

        LogText.text = "";
        //LogText.text += logindex + "\n";              //代刚ノ
        // LogText.text += dialog.textList[0] + "\n";     //代刚ノ
        // LogText.text += dialog.textList[1] + "\n";     //代刚ノ
        // LogText.text += dialog.textList[2] + "\n";     //代刚ノ

        
        for (int i = 0; i < logindex; i++)
        {
            LogText.text += dialog.textList[i] + "\n";
        }*/
    }

    void OnEnable()
    {
        logindex = PlayerPrefs.GetInt("logindex");
        LogText.text = "";
        for (int i = 0; i < logindex; i++)
        {
            LogText.text += dialog.textList[i] + "\n";
        }
    }


    /*
    // Update is called once per frame
    void Update()
    {
        
        int logindex2 = PlayerPrefs.GetInt("logindex");
        if(logindex2 != logindex)
        {
            logindex = logindex2;

            LogText.text = "";

            for (int i = 0; i < logindex; i++)
            {
                LogText.text += dialog.textList[i] + "\n";
            }
        }
    }*/

}
