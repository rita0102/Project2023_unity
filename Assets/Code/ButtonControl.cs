using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //123
    void Update()
    {
        
    }

    //切換至Game場景
    public void SwitchSceneGame()
    {
        SceneManager.LoadScene(6);
    }

    //切換至Menu場景
    public void SwitchSceneMenu()
    {
        SceneManager.LoadScene(1);
    }

    //切換至Save場景
    public void SwitchSceneSave()
    {
        SceneManager.LoadScene(2);
    }

    //切換至Setting場景
    public void SwitchSceneSetting()
    {
        SceneManager.LoadScene(3);
    }

    //切換至Log場景
    public void SwitchSceneLog()
    {
        SceneManager.LoadScene(4);
    }

    //退出遊戲
    public void QuitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
