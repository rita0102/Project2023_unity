using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SavePlayerData : MonoBehaviour
{
    [Header("Input")]
    //[SerializeField]
    public InputField playerNameInputField;
    public Text playerNameInput;
    public string playerName;

    // Start is called before the first frame update
    private void Awake()
    {
        //playerNameInputField=GetComponent<InputField>();
    }
    void Start()
    {
        
    }

    public void SaveUserName(Text inputText)
    {
        playerName = inputText.text;
        PlayerPrefs.SetString("playerName", playerName);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
    
