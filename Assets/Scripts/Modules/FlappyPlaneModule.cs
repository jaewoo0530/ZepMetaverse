using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyPlaneModule : MiniGameModule
{
    [SerializeField] private FlappyUI flappyUIPrefab;

    private FlappyUI flappyUI;

    public override void Init()
    {
        currentScore = 0;

        if (flappyUI == null)
        {
            flappyUI = Instantiate(flappyUIPrefab);
        }

        flappyUI.UpdateScore(currentScore);
        flappyUI.BestScore(bestScore);
    }

    public override void Disable()
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

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log($"Score: {currentScore}");
        flappyUI.UpdateScore(currentScore);
    }
}
