using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ch2_1_checkAns : MonoBehaviour
{

    public string InputAns;
    public int countWrong = 0;

    public int count = 2;

    public GameObject hint1;
    public GameObject hint2;
    public GameObject hint3;

    public GameObject Ans_o;
    public GameObject Ans_x;

    public void checkAns(Text inputText)
    {

        InputAns = inputText.text;

        Ans_o.SetActive(false);
        Ans_x.SetActive(false);

        if (InputAns.Equals("101"))
        {
            AnsIsRight();
        }
        else
        {
            AnsIsWrong();
        }

    }

    public void AnsIsRight()
    {
        Ans_o.SetActive(true);
        InvokeRepeating("counter", 1, 1);
    }

    public void AnsIsWrong()
    {
        countWrong++;

        Ans_x.SetActive(true);
        InvokeRepeating("counter", 1, 1);

        //¤¤¤¶´£¥Ü
        switch (countWrong)
        {
            case 1:
                hint1.SetActive(true);
                break;
            case 2:
                hint2.SetActive(true);
                break;
            case 3:
                hint3.SetActive(true);
                break;
        }
    }

    void counter()
    {
        count -= 1;

        if (count == 0)
        {
            CancelInvoke("counter");
            count = 2;
            Ans_o.SetActive(false);
            Ans_x.SetActive(false);
        }
    }
}








