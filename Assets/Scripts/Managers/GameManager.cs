using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public LobbyModule lobbyModule;
    public FlappyPlaneModule flappyPlaneModule;
    public TopDownModule topDownModule;
    public TheStackMondule theStackMondule;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // 초기 로비 모듈 활성화
        lobbyModule.Init();
    }

    // 씬 전환과 모듈 활성화
    public void EnterMiniGame(string name)
    {
        lobbyModule.Disable();

        // 씬 전환 후 미니게임 모듈 활성화
        SceneManager.LoadScene(name);
        SceneManager.sceneLoaded += OnMiniGameSceneLoaded;
    }

    private void OnMiniGameSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "FlappyPlane")
        {
            flappyPlaneModule.Init();
            SceneManager.sceneLoaded -= OnMiniGameSceneLoaded;
        }
        else if (scene.name == "TheStack")
        {
            theStackMondule.Init();
            SceneManager.sceneLoaded -= OnMiniGameSceneLoaded;
        }
        else if (scene.name == "TopDown")
        {
            topDownModule.Init();
            SceneManager.sceneLoaded -= OnMiniGameSceneLoaded;
        }
    }

    public void ReturnToLobby()
    {
        // 미니게임 모듈 비활성화
        flappyPlaneModule.Disable();

        SceneManager.LoadScene("LobbyScene");
        SceneManager.sceneLoaded += OnLobbySceneLoaded;
    }

    private void OnLobbySceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "LobbyScene")
        {
            lobbyModule.Init();
            SceneManager.sceneLoaded -= OnLobbySceneLoaded;
        }
    }
}
