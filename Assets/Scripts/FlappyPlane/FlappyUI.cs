using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlappyUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
        restartText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void BestScore(int bestScore)
    {
        bestScoreText.text = $"Best: {bestScore}";
    }
}
