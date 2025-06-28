public abstract class GameState
{
    public abstract void Enter(GameStateManager gameStateManager);
    public abstract void Exit(GameStateManager gameStateManager);
    public abstract void UpdateState(GameStateManager gameStateManager);

}
