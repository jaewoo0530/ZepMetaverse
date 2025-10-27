using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownModule : MiniGameModule
{
    public int currentScore = 0;
    public int bestScore = 0;

    [SerializeField] private TopDownManager topDownPrefab;

    private TopDownManager topDownManager;

    public override void Init()
    {
        currentScore = 0;

        if (topDownManager == null)
        {
            topDownManager = Instantiate(topDownPrefab);
        }
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
        }
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log($"Score: {currentScore}");
    }
}
