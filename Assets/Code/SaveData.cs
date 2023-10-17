using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField]
    PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void Save()
    {
        PlayerPrefs.SetString("name",playerData.playerName);
        PlayerPrefs.SetInt("San", playerData.sanity);
        PlayerPrefs.SetString("Current Scene", playerData.currentScene);
    }

    public void Load()
    {
        PlayerPrefs.GetString("name", playerData.playerName);
        PlayerPrefs.GetInt("San", playerData.sanity);
        PlayerPrefs.GetString("Current Scene", playerData.currentScene);
    }

    [SerializeField]
    public class PlayerData
    {
        public string currentScene;
        public string playerName;
        public int sanity;
    }
}
