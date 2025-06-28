public class GameWinState : GameState
{

    public override void Enter(GameStateManager gameStateManager)
    {
        UiManager.Instance.ShowWinScreen(
          onRestart: () => gameStateManager.SwitchState(gameStateManager.playState),
          onMenu: () => gameStateManager.SwitchState(gameStateManager.mainMenuState)
        );
        SoundManager.Instance.PlaySFX(GameConfigProvider.Instance.Sounds.gameWin);
    }

    public override void Exit(GameStateManager gameStateManager)
    {
        UiManager.Instance.HideWinScreen();
    }

    public override void UpdateState(GameStateManager gameStateManager)
    {
    }
}
