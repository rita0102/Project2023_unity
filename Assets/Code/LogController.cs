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

    // Start is called before the first frame update
    void Start()
    {
        dialog.LogText.text = "";
        for (int i = 0; i <= dialog.logindex; i++)
        {
            dialog.LogText.text += dialog.textList[dialog.logindex] + "\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
