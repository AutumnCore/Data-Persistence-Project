using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistentDataManager : MonoBehaviour
{
    public static PersistentDataManager Instance;

    public string bestPlayerName;
    public int bestScore;

    public string currentPlayerName;

    private string path;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        path = Application.persistentDataPath + "/savefile.json";
        LoadBestScoreFromDisc();
    }

    private void Start()
    {
        
    }

    public void SetCurrentPlayerName(string name)
    {
        currentPlayerName = name;
    }

    public void CompareScore(int points)
    {
        if (bestScore < points)
        {
            bestScore = points;
            bestPlayerName = currentPlayerName;
        }
    }

    public void PassBestScore()
    {
        BestScoreText bestScoreText = Object.FindObjectOfType<BestScoreText>();
        bestScoreText.SetBestScoreText(bestPlayerName, bestScore);
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveBestScoreToDisc(string name, int score)
    {
        SaveData data = new SaveData();
        data.name = name;
        data.score = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public void LoadBestScoreFromDisc()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayerName = data.name;
            bestScore = data.score;
        }
    }

    
    private void OnApplicationQuit()
    {
        SaveBestScoreToDisc(bestPlayerName, bestScore);
    }
}
