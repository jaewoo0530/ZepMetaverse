using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyPlaneModule : MonoBehaviour
{
    private int currentScore = 0;
    [SerializeField] private FlappyUI flappyUI;

    public void Init()
    {
        flappyUI = FindObjectOfType<FlappyUI>();
        currentScore = 0;
        flappyUI.UpdateScore(currentScore);
    }

    public void Disable()
    {

    }

    public void GameOver()
    {
        Debug.Log("Game Over");
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
