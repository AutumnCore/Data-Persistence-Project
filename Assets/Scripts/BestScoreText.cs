using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScoreText : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;

    void OnEnable()
    {
        if(NameManager.Instance != null)
        {
            NameManager.Instance.PassBestScore();
        }
    }
    public void SetBestScoreText(string playerName, int bestScore)
    {
        bestScoreText.text = "Best Score: " + playerName + ": " + bestScore;
    }
}
