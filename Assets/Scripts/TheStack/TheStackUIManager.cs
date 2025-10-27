using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TheStackUIManager : MonoBehaviour
{
    public GameObject homeUI;
    public GameObject gameOverUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    public void StartGame()
    {
        GameManager.Instance.theStackModule.isGame = true;
        homeUI.SetActive(false);
    }

    public void ExitGame()
    {
        GameManager.Instance.theStackModule.ExitGame();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void BestScore(int bestScore)
    {
        bestScoreText.text = $"Best: {bestScore}";
    }

    public void GameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        GameManager.Instance.theStackModule.RestartGame();
    }
}
