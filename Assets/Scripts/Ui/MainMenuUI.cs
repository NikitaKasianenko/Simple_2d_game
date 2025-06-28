using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private TextMeshProUGUI recordText;

    public void Init(Action onPlayClicked)
    {
        float time = PlayerPrefs.GetFloat("BestTime", 0f);
        recordText.text = TimeSpan.FromMinutes(time).ToString(@"mm\:ss\.ff");
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(() => onPlayClicked?.Invoke());
    }
}
    