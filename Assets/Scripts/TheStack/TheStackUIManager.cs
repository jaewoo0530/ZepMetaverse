using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TheStackUIManager : MonoBehaviour
{
    public GameObject homeUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    public void StartGame()
    {
        GameManager.Instance.theStackMondule.isGame = true;
        homeUI.SetActive(false);
    }

    public void ExitGame()
    {
        GameManager.Instance.ReturnToLobby();
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
