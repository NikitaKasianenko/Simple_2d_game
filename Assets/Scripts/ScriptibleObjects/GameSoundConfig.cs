using UnityEngine;

[CreateAssetMenu(fileName = "GameSoundConfig", menuName = "Configs/Game Sounds")]
public class GameSoundConfig : ScriptableObject
{

    [Header("SFX Clips")]
    public AudioClip freeze;
    public AudioClip doublePoint;
    public AudioClip inGame;
    public AudioClip InMainMenu;
    public AudioClip gameWin;
    public AudioClip gameOver;
    public AudioClip missClick;
    public AudioClip hitClick;
}