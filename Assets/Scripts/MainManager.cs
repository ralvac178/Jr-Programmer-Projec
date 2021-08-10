using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class MainManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static MainManager instance;
    public Color teamColor; // new variable declared

    public void Awake()
    {
        //// start of new code
        if (instance != null)
        {
           Destroy(gameObject);
           return;
        }
        //// end of new code
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.teamColor = teamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            teamColor = data.teamColor;
        }
    }


    [System.Serializable]
    class SaveData
    {
        public Color teamColor;
    }
}
