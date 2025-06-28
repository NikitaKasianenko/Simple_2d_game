using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenUI : MonoBehaviour
{
    [SerializeField] private Button restartButton,menuButton;
    [SerializeField] private TextMeshProUGUI score;

    public void Init( Action onRestart, Action onMenu)
    {
        float time = PlayerPrefs.GetFloat("LastTime", 0f);
        score.text = TimeSpan.FromMinutes(time).ToString(@"mm\:ss\.ff");

        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(() => onRestart?.Invoke());

        menuButton.onClick.RemoveAllListeners();
        menuButton.onClick.AddListener(() => onMenu?.Invoke());
    }

}
