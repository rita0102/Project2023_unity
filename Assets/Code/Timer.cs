using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int time_int = 15;
    public Text time_UI;

    public ch2_question ch2Q;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("timer", 1, 1);
        //�@���A�C���ƩI�stimer�禡�C(�}�l�˼ƭp��)�C
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */

    void timer()
    {
        time_int -= 1;
        time_UI.text = time_int + " s";

        if (time_int == 0)
        {
            time_UI.text = "time up";
            CancelInvoke("timer"); //�������ƩI�stimer�禡�C(����˼ƭp��)

            ch2Q.score--;
            ch2Q.WrongAns();
        }
        if (ch2Q.stopTime)
        {
            ch2Q.stopTime = false;
            CancelInvoke("timer"); //�������ƩI�stimer�禡�C(����˼ƭp��)
        }
    }
}
