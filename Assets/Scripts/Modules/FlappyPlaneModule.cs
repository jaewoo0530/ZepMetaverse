using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyPlaneModule : MonoBehaviour
{
    private int currentScore = 0;
    private int bestScore = 0;

    [SerializeField] private FlappyUI flappyUIPrefab;

    private FlappyUI flappyUI;

    public void Init()
    {
        currentScore = 0;

        if (flappyUI == null)
        {
            flappyUI = Instantiate(flappyUIPrefab);
        }

        flappyUI.UpdateScore(currentScore);
        flappyUI.BestScore(bestScore);
    }

    public void Disable()
    {

    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        if (bestScore < currentScore)
        {
            bestScore = currentScore;
            flappyUI.BestScore(bestScore);
        }

        flappyUI.SetRestart();
    }

    public void RestartGame()
    {
        GameManager.Instance.EnterMiniGame(1);
    }

    public void ExitGame()
    {
        GameManager.Instance.ReturnToLobby();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log($"Score: {currentScore}");
        flappyUI.UpdateScore(currentScore);
    }
}
