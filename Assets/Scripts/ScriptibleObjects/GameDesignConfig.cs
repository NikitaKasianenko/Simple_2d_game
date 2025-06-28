using UnityEngine;

[CreateAssetMenu(fileName = "GameDesignConfig", menuName = "Configs/Game Design")]
public class GameDesignConfig : ScriptableObject
{
    public Sprite[] targetSprites;
    public Vector2 playableAreaAnchorMin = new Vector2(0.1f, 0.1f);
    public Vector2 playableAreaAnchorMax = new Vector2(0.9f, 0.9f);
}