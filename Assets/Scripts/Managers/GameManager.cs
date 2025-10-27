using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public LobbyModule lobbyModule;
    public FlappyPlaneModule flappyPlaneModule;
    public TopDownModule topDownModule;
    public TheStackModule theStackModule;

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
        // �ʱ� �κ� ��� Ȱ��ȭ
        lobbyModule.Init();
    }

    // �� ��ȯ�� ��� Ȱ��ȭ
    public void EnterMiniGame(string name)
    {
        lobbyModule.Disable();

        // �� ��ȯ �� �̴ϰ��� ��� Ȱ��ȭ
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
            theStackModule.Init();
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
