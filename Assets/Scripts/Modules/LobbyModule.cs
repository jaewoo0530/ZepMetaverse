using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyModule : MonoBehaviour
{
    private LobbyPlayerController playerController;


    public Vector3 savedPosition;

    [SerializeField] private LobbyUI lobbyUIPrefab;

    private LobbyUI lobbyUI;

    public void Init()
    {
        playerController = FindObjectOfType<LobbyPlayerController>();

        if (lobbyUI == null)
        {
            lobbyUI = Instantiate(lobbyUIPrefab);
        }

        lobbyUI.PlaneBestScore(GameManager.Instance.flappyPlaneModule.bestScore);
        lobbyUI.StackBestScore(GameManager.Instance.theStackModule.bestScore);
    }

    public void Disable()
    {
        if (playerController != null)
        {
            playerController.SavePoint();
        }
    }
}
