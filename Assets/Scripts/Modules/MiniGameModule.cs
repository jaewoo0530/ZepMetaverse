using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameModule : MonoBehaviour
{
    public virtual void Init()
    {

    }

    public virtual void Disable()
    {

    }

    public void RestartGame()
    {
        GameManager.Instance.EnterMiniGame(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        GameManager.Instance.ReturnToLobby();
    }
}
