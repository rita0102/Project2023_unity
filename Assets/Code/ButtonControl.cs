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

    //������Game����
    public void SwitchSceneGame()
    {
        SceneManager.LoadScene(6);
    }

    //������Menu����
    public void SwitchSceneMenu()
    {
        SceneManager.LoadScene(1);
    }

    //������Save����
    public void SwitchSceneSave()
    {
        SceneManager.LoadScene(2);
    }

    //������Setting����
    public void SwitchSceneSetting()
    {
        SceneManager.LoadScene(3);
    }

    //������Log����
    public void SwitchSceneLog()
    {
        SceneManager.LoadScene(4);
    }

    //�h�X�C��
    public void QuitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
