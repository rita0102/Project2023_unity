using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    [SerializeField]
    public Image Sanity;
    [SerializeField]
    public Sprite green;
    [SerializeField]
    public Sprite yellow;
    [SerializeField]
    public Sprite red;
    public float maxSanity = 100;
    public float currentSanity;

    private void Awake()
    {
        if (PlayerPrefs.GetFloat("sanity") != 0)
        {
            currentSanity = PlayerPrefs.GetFloat("sanity");
        }
        else
        {
            currentSanity = maxSanity;
        }
        
    }

    private void Filler()
    {
        Sanity.fillAmount = currentSanity/maxSanity;
        PlayerPrefs.SetFloat("sanity", currentSanity);
        if (currentSanity > 80) 
        {
            Sanity.sprite= green;
        }
        else if (currentSanity > 50)
        {
            Sanity.sprite = yellow;
        }
        else
        {
            Sanity.sprite= red;
        }
    }

    void Update()
    {
        //Test
        //«ö¤UH¶s¦©¦å
        if (Input.GetKeyDown(KeyCode.H) && currentSanity>0)
        {
            //±µ¨ü¶Ë®`
            currentSanity = currentSanity - 10;
        }
        Filler();
    }
}
