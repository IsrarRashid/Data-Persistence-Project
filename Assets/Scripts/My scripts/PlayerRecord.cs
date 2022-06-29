using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerRecord : MonoBehaviour
{
    public static PlayerRecord Instance; // new variable declared

    public int temporaryScore;
    public string temporaryName;

    public int finalScore;
    public string finalName;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string savedName;
        public int savedScore;
    }

    public void SaveRecord()
    {
        SaveData saveData = new SaveData();
        saveData.savedName = finalName;
        saveData.savedScore = finalScore;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            finalScore = saveData.savedScore;
            finalName = saveData.savedName;
        }
    }

    public void ResetFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
