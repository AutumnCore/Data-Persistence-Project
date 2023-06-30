using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameManager : MonoBehaviour
{
    public static NameManager Instance;

    BestScoreText bestScoreText;

    public TMP_InputField nameInputField;
    public string playerName;
    public int bestScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        bestScoreText = Object.FindObjectOfType<BestScoreText>();
        bestScoreText.SetBestScoreText(playerName, bestScore);
    }

    public void SaveName()
    {
        playerName = nameInputField.text;
    }

    public void CompareScore(int points)
    {
        if(bestScore < points)
        {
            bestScore = points;
        }
    }

    public void PassBestScore()
    {
        bestScoreText = Object.FindObjectOfType<BestScoreText>();
        bestScoreText.SetBestScoreText(playerName, bestScore);
    }
}
