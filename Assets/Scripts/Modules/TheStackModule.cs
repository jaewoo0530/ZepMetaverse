using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheStackModule : MiniGameModule
{
    public bool isGame = false;

    [SerializeField] TheStackUIManager theStackUIManagerPrefab;

    private TheStackUIManager theStackUIManager;

    private bool isFirstLoading = true;

    public override void Init()
    {
        currentScore = 0;

        if (theStackUIManager == null)
        {
            theStackUIManager = Instantiate(theStackUIManagerPrefab);
        }

        theStackUIManager.UpdateScore(currentScore);
        theStackUIManager.BestScore(bestScore);

        if (!isFirstLoading)
        {
            isGame = true;
        }
        else
        {
            theStackUIManager.homeUI.SetActive(true);
            isFirstLoading = false;
        }
    }

    public override void Disable()
    {
        isFirstLoading = true;
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
