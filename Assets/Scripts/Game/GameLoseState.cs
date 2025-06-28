public class GameLoseState : GameState
{
    public override void Enter(GameStateManager gameStateManager)
    {
        UiManager.Instance.ShowLoseScreen(
          onRestart: () => gameStateManager.SwitchState(gameStateManager.playState),
          onMenu: () => gameStateManager.SwitchState(gameStateManager.mainMenuState)
        );
        SoundManager.Instance.PlaySFX(GameConfigProvider.Instance.Sounds.gameOver);
    }

    public override void Exit(GameStateManager gameStateManager)
    {
        UiManager.Instance.HideLoseScreen();
    }

    public override void UpdateState(GameStateManager gameStateManager)
    {
    }
}
