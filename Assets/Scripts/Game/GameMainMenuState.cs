using UnityEngine;

public class GameMainMenuState : GameState
{
    public override void Enter(GameStateManager gameStateManager)
    {
        Debug.Log("Entering Main Menu State");

        UiManager.Instance.ShowMainMenu(() =>
        {
            gameStateManager.SwitchState(gameStateManager.playState);
        });
        SoundManager.Instance.PlayLoop(GameConfigProvider.Instance.Sounds.InMainMenu);
    }

    public override void Exit(GameStateManager gameStateManager)
    {
        UiManager.Instance.HideMainMenu();
        SoundManager.Instance.StopLoop();
    }

    public override void UpdateState(GameStateManager gameStateManager) { }
}
