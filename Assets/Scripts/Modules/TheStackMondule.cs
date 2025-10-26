using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheStackMondule : MiniGameModule
{
    private int currentScore = 0;
    private int bestScore = 0;

    public override void Init()
    {
        currentScore = 0;
    }

    public override void Disable()
    {

    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log($"Score: {currentScore}");
    }

}
