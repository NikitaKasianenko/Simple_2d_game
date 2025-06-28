using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Timer,Score;
    [SerializeField] private Image filler;
    [SerializeField] private Button exitButton;

    private float totalTime;
    private float totalScore;

    private void Start()
    {
        totalTime = GameConfigProvider.Instance.Economy.gameTime;
        totalScore = GameConfigProvider.Instance.Economy.targetScore;
        filler.fillAmount = 1f;
    }
    public void Init(Action onPlayClicked)
    {
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(() => onPlayClicked?.Invoke());
    }

    public void UpdateScore(int score)
    {
        Score.text = $"{score} / {totalScore}";
    }
    public void UpdateTimer(float time)
    {
        var timeSpan = TimeSpan.FromMinutes(time);
        Timer.text = timeSpan.ToString(@"mm\:ss\.ff");

        if (totalTime > 0)
        {
            filler.fillAmount = Mathf.Clamp01(time / totalTime);
        }
    }

}

