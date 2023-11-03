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

    public string playerName;


    // Start is called before the first frame update
    void Start()
    {
        /*
        if (string.Compare(PlayerPrefs.GetString("playerName"), "") == 1)
        {
            playerName = "еDид";
        }
        else
        {
            playerName = PlayerPrefs.GetString("playerName");
        }
        */
    }

    void OnEnable()
    {
        logindex = PlayerPrefs.GetInt("logindex");

        if (string.Compare(PlayerPrefs.GetString("playerName"), "") == 1)
        {
            playerName = "еDид";
        }
        else
        {
            playerName = PlayerPrefs.GetString("playerName");
        }

        LogText.text = "";
        for (int i = 0; i < logindex * 2; i+=2)
        {
            if (string.Compare(dialog.textList[i], "еDид") == 1)
            {
                LogText.text += playerName + "\t\t\t" + dialog.textList[i + 1] + "\n";
            }
            else
            {
                LogText.text += dialog.textList[i] + "\t\t" + dialog.textList[i + 1] + "\n";
            }
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
