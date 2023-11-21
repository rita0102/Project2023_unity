using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ch2_question : MonoBehaviour
{
    public int score;
    public int count = 2;
    public bool stopTime = false;

    public Text score1_UI;
    public Text score2_UI;
    public Text score3_UI;
    public Text score4_UI;
    public Text score5_UI;
    public Text score6_UI;
    public Text score7_UI;
    public Text score8_UI;

    public GameObject PanelQ1;
    public GameObject PanelQ2;
    public GameObject PanelQ3;
    public GameObject PanelQ4;
    public GameObject PanelQ5;
    public GameObject PanelQ6;
    public GameObject PanelQ7;
    public GameObject PanelQ8;

    public GameObject Ans_o;
    public GameObject Ans_x;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        score1_UI.text = score + "";
        PanelQ1.SetActive(true);
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */

    public void WrongAns()
    {
        score--;
        stopTime = true;
        Ans_x.SetActive(true);
        InvokeRepeating("counter", 1, 1);
    }

    public void CorrectAns()
    {
        score++;
        stopTime = true;
        Ans_o.SetActive(true);
        InvokeRepeating("counter", 1, 1);
    }

    public void PanelActiveControl()
    {
        Ans_o.SetActive(false);
        Ans_x.SetActive(false);


        if (PanelQ1.activeSelf)
        {
            PanelQ1.SetActive(false);
            PanelQ2.SetActive(true);
            score2_UI.text = score + "";
        }
        else if (PanelQ2.activeSelf)
        {
            PanelQ2.SetActive(false);
            PanelQ3.SetActive(true);
            score3_UI.text = score + "";
        }
        else if (PanelQ3.activeSelf)
        {
            PanelQ3.SetActive(false);
            PanelQ4.SetActive(true);
            score4_UI.text = score + "";
        }
        else if (PanelQ4.activeSelf)
        {
            PanelQ4.SetActive(false);
            PanelQ5.SetActive(true);
            score5_UI.text = score + "";
        }
        else if (PanelQ5.activeSelf)
        {
            PanelQ5.SetActive(false);
            PanelQ6.SetActive(true);
            score6_UI.text = score + "";
        }
        else if (PanelQ6.activeSelf)
        {
            PanelQ6.SetActive(false);
            PanelQ7.SetActive(true);
            score7_UI.text = score + "";
        }
        else if (PanelQ7.activeSelf)
        {
            PanelQ7.SetActive(false);
            PanelQ8.SetActive(true);
            score8_UI.text = score + "";
        }
        else if (PanelQ8.activeSelf)
        {
            /*
            PanelActiveFalse();
            PanelQ2.SetActive(true);
            */
        }
    }

    void counter()
    {
        count -= 1;

        if (count == 0)
        {
            CancelInvoke("counter");
            count = 2;
            PanelActiveControl();
        }
    }
}
