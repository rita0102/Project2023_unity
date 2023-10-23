using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    Button NewGameBtn;
    Button ContinueBtn;
    Button QuitBtn;

    void Awake()
    {
        NewGameBtn = transform.GetChild(0).GetComponent<Button>();
        ContinueBtn = transform.GetChild(1).GetComponent<Button>();
        QuitBtn = transform.GetChild(2).GetComponent<Button>();

        NewGameBtn.onClick.AddListener(NewGame);
        ContinueBtn.onClick.AddListener(Continue);
        QuitBtn.onClick.AddListener(QuitGame);
    }

    void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("InputPlayerData");

    }

    void Continue()
    {
        int currentScene = PlayerPrefs.GetInt("CurrentScene");
        SceneManager.LoadScene(currentScene);
    }

    void QuitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
