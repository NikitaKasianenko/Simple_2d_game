using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/Game Config")]
public class GameConfig : ScriptableObject
{
    [Header("Game settings")]
    public int scorePerClick = 1;
    public int targetScore = 10;
    public float gameTime = 30f;
    public float targetLifetime = 3f;
    public float freezeTime = 1f;
    [Header("Spawn settings")]
    [Tooltip("The sum of SpawnRate should be 1")]
    public float doublePointSpawnRate = 0.05f;
    public float freezzerSpawnRate = 0.2f;
    public float defaultSpawnRate = 0.75f;
    [Header("Seed settings")]
    public bool useCustomSeed = false;
    public int seed = 0;
}
