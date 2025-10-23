using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyPlaneModule : MonoBehaviour
{
    private int currentScore = 0;

    public void Init()
    {

    }

    public void Disable()
    {

    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log($"Score: {currentScore}");
    }
}
