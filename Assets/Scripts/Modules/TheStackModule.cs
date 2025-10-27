using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheStackModule : MiniGameModule
{
    public bool isGame = false;

    [SerializeField] TheStackUIManager theStackUIManagerPrefab;

    private TheStackUIManager theStackUIManager;

    public override void Init()
    {
        currentScore = 0;

        if (theStackUIManager == null)
        {
            theStackUIManager = Instantiate(theStackUIManagerPrefab);
        }

        theStackUIManager.UpdateScore(currentScore);
        theStackUIManager.BestScore(bestScore);
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
            theStackUIManager.BestScore(bestScore);
        }

        isGame = false;

        theStackUIManager.GameOverUI();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log($"Score: {currentScore}");
        theStackUIManager.UpdateScore(currentScore);
    }
}
