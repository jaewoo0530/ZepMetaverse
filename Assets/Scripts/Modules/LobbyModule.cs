using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyModule : MonoBehaviour
{
    private LobbyPlayerController playerController;
    public Vector3 savedPosition;

    public void Init()
    {
        playerController = FindObjectOfType<LobbyPlayerController>();
    }

    public void Disable()
    {
        playerController.SavePoint();
    }
}
