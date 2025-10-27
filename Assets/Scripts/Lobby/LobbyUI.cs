using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyUI : MonoBehaviour
{

    public TextMeshProUGUI planeBestScoreText;
    public TextMeshProUGUI stackBestScoreText;
    public TextMeshProUGUI topDownBestScoreText;

    public void PlaneBestScore(int bestScore)
    {
        planeBestScoreText.text = $"Flappy Plane: {bestScore}";
    }

    public void StackBestScore(int bestScore)
    {
        stackBestScoreText.text = $"The Stack: {bestScore}";
    }

    public void TopDownBestScore(int bestScore)
    {
        topDownBestScoreText.text = $"TopDown: {bestScore}";
    }
}
