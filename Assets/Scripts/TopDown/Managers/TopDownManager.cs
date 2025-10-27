using UnityEngine;

public class TopDownManager : MonoBehaviour
{
    public static TopDownManager instance;
    public PlayerController player { get; private set; }
    private ResourceController _playerResourceController;

    [SerializeField] private int currentWaveIndex = 0;

    [SerializeField] private EnemyManager enemyManager;

    private TopDownModule topDownModule;
    private TopDownUIManager topDownUIManager;
    public static bool isFirstLoading = true;

    private void Awake()
    {
        topDownModule = GameManager.Instance.topDownModule;

        instance = this;

        player = FindObjectOfType<PlayerController>();
        player.Init(this);

        topDownUIManager = FindObjectOfType<TopDownUIManager>();

        enemyManager = GetComponentInChildren<EnemyManager>();
        enemyManager.Init(this);


        _playerResourceController = player.GetComponent<ResourceController>();
        _playerResourceController.RemoveHealthChangeEvent(topDownUIManager.ChangePlayerHP);
        _playerResourceController.AddHealthChangeEvent(topDownUIManager.ChangePlayerHP);
    }

    private void Start()
    {
        topDownUIManager.BestScore(topDownModule.bestScore);
        if (!isFirstLoading)
        {
            StartGame();
        }
        else
        {
            isFirstLoading = false;
        }
    }

    public void StartGame()
    {
        topDownUIManager.SetPlayGame();
        StartNextWave();
    }

    void StartNextWave()
    {
        topDownModule.AddScore(1);
        currentWaveIndex += 1;
        enemyManager.StartWave(1 + currentWaveIndex / 5);
        topDownUIManager.ChangeWave(currentWaveIndex);
    }

    public void EndOfWave()
    {
        StartNextWave();
    }

    public void GameOver()
    {
        topDownModule.GameOver();
        topDownUIManager.BestScore(topDownModule.bestScore);
        enemyManager.StopWave();
        topDownUIManager.SetGameOver();
    }
}
