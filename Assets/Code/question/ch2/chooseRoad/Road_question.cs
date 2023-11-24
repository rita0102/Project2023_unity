using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Road_question : MonoBehaviour
{
    public GameObject PanelQ1;
    public GameObject PanelQ2;
    public GameObject Panel_GameOver;
    public GameObject Panel_GameClear;

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    public void WrongAns()
    {
        if (PanelQ1.activeSelf)
        {
            PanelQ1.SetActive(false);
            Panel_GameOver.SetActive(true);
        }
        else if (PanelQ2.activeSelf)
        {
            PanelQ2.SetActive(false);
            Panel_GameOver.SetActive(true);
        }
    }

    public void CorrectAns()
    {
        if (PanelQ1.activeSelf)
        {
            PanelQ1.SetActive(false);
            PanelQ2.SetActive(true);
        }
        else if (PanelQ2.activeSelf)
        {
            PanelQ2.SetActive(false);
            Panel_GameClear.SetActive(true);
        }
    }
}
