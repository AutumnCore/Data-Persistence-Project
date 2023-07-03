using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScoreText : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;

    void Start()
    {
        if(PersistentDataManager.Instance != null)
        {
            PersistentDataManager.Instance.PassBestScore();
        }
    }
    public void SetBestScoreText(string playerName, int bestScore)
    {
        bestScoreText.text = "Best Score: " + playerName + ": " + bestScore;
    }
}
