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
    public int logindex;

    

    // Start is called before the first frame update
    void Start()
    {
        LogText.text = "";
        logindex = 0;
        
        for (int i = 0; i <= logindex; i++)
        {
            LogText.text += dialog.textList[logindex] + "\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
