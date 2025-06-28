using UnityEngine;

public class GameConfigProvider : MonoBehaviour
{
    public static GameConfigProvider Instance { get; private set; }

    [Header("Configs")]
    [SerializeField] private GameConfig economyConfig;
    [SerializeField] private GameDesignConfig designConfig;
    [SerializeField] private GameSoundConfig soundConfig;

    public GameConfig Economy => economyConfig;
    public GameDesignConfig Design => designConfig;
    public GameSoundConfig Sounds => soundConfig;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
