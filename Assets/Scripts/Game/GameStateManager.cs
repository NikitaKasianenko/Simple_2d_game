using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    GameState currentState;

    public GameMainMenuState mainMenuState = new GameMainMenuState();
    public GamePlayState playState = new GamePlayState();
    public GameWinState WinState = new GameWinState();
    public GameLoseState LoseState = new GameLoseState();

    void Start()
    {
        currentState = mainMenuState;
        currentState.Enter(this);
    }

    public void SwitchState(GameState newState)
    {
        currentState.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

}
