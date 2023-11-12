using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using System.Reflection;
using System.Threading;
using Unity.VisualScripting;


public class BookManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bookSystem;
    [SerializeField]
    private GameObject bookPanel;
    [SerializeField]
    private Image bookImage;
    [SerializeField]
    private Sprite[] bookSprite;
    [SerializeField]
    private Button nextButton;
    [SerializeField]
    private Button prevButton;

    private int index;

    private void Awake()
    {
        index = 0;
        bookSystem.SetActive(true);
        showBook();
    }
    private void Update()
    {
        showBook();
    }

    private void showBook()
    {
        prevButton.gameObject.SetActive(true);
        nextButton.GetComponentInChildren<Text>().text = "下一頁";
        prevButton.GetComponentInChildren<Text>().text = "上一頁";
        if (index == 0)
        {
            prevButton.gameObject.SetActive(false);
            bookImage.sprite = bookSprite[index];
        }

        else if(index==bookSprite.Length-1)
        {
            nextButton.GetComponentInChildren<Text>().text = "結束閱讀";
            bookImage.sprite = bookSprite[index];
        }

        else if(index>= bookSprite.Length)
        {
            bookSystem.SetActive(false);
        }

        else
        {
            prevButton.gameObject.SetActive(true);
            nextButton.GetComponentInChildren<Text>().text = "下一頁";
            prevButton.GetComponentInChildren<Text>().text = "上一頁";
            bookImage.sprite = bookSprite[index];
        }

            
    }

    public void Next()
    {
        index++;
    }
    public void Prev()
    {
        index--;
    }
}
