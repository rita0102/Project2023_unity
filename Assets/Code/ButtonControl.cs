using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ButtonControl : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject savePanel;
    public GameObject settingPanel;
    public GameObject logPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //������Game����->���è�Lpanel
    public void SwitchSceneGame()
    {
        //SceneManager.LoadScene(6);
        menuPanel.SetActive(false);
        savePanel.SetActive(false);
        settingPanel.SetActive(false);
        logPanel.SetActive(false);
    }

    //������Menu����->���menu panel
    public void SwitchSceneMenu()
    {
        //SceneManager.LoadScene(1);
        menuPanel.SetActive(true);
        savePanel.SetActive(false);
        settingPanel.SetActive(false);
        logPanel.SetActive(false);
    }

    //������Save����->���save panel
    public void SwitchSceneSave()
    {
        //SceneManager.LoadScene(2);
        savePanel.SetActive(true);
        menuPanel.SetActive(false);
        settingPanel.SetActive(false);
        logPanel.SetActive(false);
    }

    //������Setting����->���setting panel
    public void SwitchSceneSetting()
    {
        //SceneManager.LoadScene(3);
        settingPanel.SetActive(true);
        menuPanel.SetActive(false);
        savePanel.SetActive(false);
        logPanel.SetActive(false);
    }

    //������Log����->���log panel
    public void SwitchSceneLog()
    {
        //SceneManager.LoadScene(4);
        logPanel.SetActive(true);
        menuPanel.SetActive(false);
        savePanel.SetActive(false);
        settingPanel.SetActive(false);
    }

    //�h�X�C��
    public void QuitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
