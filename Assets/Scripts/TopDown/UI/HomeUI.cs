using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    public override void Init(TopDownUIManager uiManager)
    {
        base.Init(uiManager);
        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickStartButton()
    {
        GameManager.Instance.EnterMiniGame("TopDown");
    }

    public void OnClickExitButton()
    {
        GameManager.Instance.ReturnToLobby();
    }

    protected override UIState GetUIState()
    {
        return UIState.Home;
    }
}