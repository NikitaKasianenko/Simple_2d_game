using System.Collections;
using UnityEngine;

public class GamePlayState : GameState
{

    public int score { get; private set; } = 0;
    private float timer;
    private bool isRunning = false;

    private TargetSpawner targetSpawner;    


    public override void Enter(GameStateManager gameStateManager)
    {
        UiManager.Instance.ShowGameUI(() => onExit(gameStateManager));
        UiManager.Instance.UpdateScore(score);

        targetSpawner = GameObject.FindGameObjectWithTag("TargetSpawner").GetComponent<TargetSpawner>();
        targetSpawner.StartSpawning((type) => OnTargetClicked(gameStateManager,type));

        timer = GameConfigProvider.Instance.Economy.gameTime;
        isRunning = true;
        SoundManager.Instance.PlayLoop(GameConfigProvider.Instance.Sounds.inGame);

    }

    private void OnTargetClicked(GameStateManager gameStateManager, BoosterType type)
    {
        switch (type)
        {
            case BoosterType.Freezer:
                UiManager.Instance.PlayFreezeEffect();
                SoundManager.Instance.PlaySFX(GameConfigProvider.Instance.Sounds.freeze);
                gameStateManager.StartCoroutine(ResumeAfterDelay(GameConfigProvider.Instance.Economy.freezeTime));
                break;
            case BoosterType.Doublepoint:
                score += 2 * GameConfigProvider.Instance.Economy.scorePerClick;
                SoundManager.Instance.PlaySFX(GameConfigProvider.Instance.Sounds.doublePoint);
                break;
            case BoosterType.None:
                SoundManager.Instance.PlaySFX(GameConfigProvider.Instance.Sounds.hitClick);
                score += GameConfigProvider.Instance.Economy.scorePerClick;
                break;
        }
        UpdateScore();

        // temp
        if(score < GameConfigProvider.Instance.Economy.targetScore)
        {
            targetSpawner.HandleClicked();
        }
    }


    public override void Exit(GameStateManager gameStateManager)
    {
        SoundManager.Instance.StopLoop();
        targetSpawner.StopSpawning();
        score = 0;
        isRunning = false;
    }

    public override void UpdateState(GameStateManager gameStateManager)
    {
        if (isRunning)
        {
            timer -= Time.deltaTime;
        };
        UpdateTimer();

        if (score >= GameConfigProvider.Instance.Economy.targetScore)
        {
            SaveScore();
            gameStateManager.SwitchState(gameStateManager.WinState);
        }

        if (timer <= 0f)
        {
            gameStateManager.SwitchState(gameStateManager.LoseState);
        }
    }

   

    private void onExit(GameStateManager gameStateManager)
    {
        gameStateManager.SwitchState(gameStateManager.mainMenuState);
    }

    private void SaveScore()
    {
        if (timer > PlayerPrefs.GetFloat("BestTime", 0f))
        {
            PlayerPrefs.SetFloat("BestTime", timer);
        }
        PlayerPrefs.SetFloat("LastTime", timer);
        PlayerPrefs.Save();
    }

    private IEnumerator ResumeAfterDelay(float delay)
    {
        isRunning = false;
        yield return new WaitForSeconds(delay);
        isRunning = true;
    }

    private void UpdateScore()
    {
        UiManager.Instance.UpdateScore(score);
    }
    private void UpdateTimer()
    {
        UiManager.Instance.UpdateTimer(timer);
    }
}
