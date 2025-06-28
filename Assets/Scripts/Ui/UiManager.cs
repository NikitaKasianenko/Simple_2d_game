using System;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }

    [Header("Main Screens")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [Header("Spawn Area")]
    [SerializeField] private GameObject SpawnArea;
    [Header("Freezer")]
    [SerializeField] private FrezzerFX freezer;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SpawnArea.GetComponent<RectTransform>().anchorMin = GameConfigProvider.Instance.Design.playableAreaAnchorMin;
        SpawnArea.GetComponent<RectTransform>().anchorMax = GameConfigProvider.Instance.Design.playableAreaAnchorMax;

    }

    public void ShowMainMenu(Action onPlayClicked)
    {
        mainMenu.SetActive(true);
        gameUI.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);

        mainMenu.GetComponent<MainMenuUI>().Init(onPlayClicked);
    }

    public void PlayFreezeEffect()
    {
        freezer?.PlayFade();
    }


    public void HideMainMenu()
    {
        mainMenu.SetActive(false);
    }

    public void ShowGameUI(Action onPlayClicked)
    {
        HideMainMenu();
        gameUI.GetComponent<GameUI>().Init(onPlayClicked);
        gameUI.SetActive(true);
    }

    public void HideGameUI()
    {
        gameUI.SetActive(false);
    }

    public void ShowWinScreen(Action onRestart, Action onMenu)
    {
        winScreen.SetActive(true);
        winScreen.GetComponent<WinScreenUI>().Init(onRestart, onMenu);
    }

    public void HideWinScreen()
    {
        winScreen.SetActive(false);
    }

    public void ShowLoseScreen(Action onRestart, Action onMenu)
    {
        loseScreen.SetActive(true);
        loseScreen.GetComponent<LoseScreenUI>().Init(onRestart, onMenu);
    }

    public void HideLoseScreen()
    {
        loseScreen.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        gameUI.GetComponent<GameUI>().UpdateScore(score);
    }
    public void UpdateTimer(float time)
    {
        gameUI.GetComponent<GameUI>().UpdateTimer(time);
    }
}
