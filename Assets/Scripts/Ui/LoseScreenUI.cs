using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreenUI : MonoBehaviour
{
    [SerializeField] private Button restartButton, menuButton;

    public void Init(Action onRestart, Action onMenu)
    {
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(() => onRestart?.Invoke());

        menuButton.onClick.RemoveAllListeners();
        menuButton.onClick.AddListener(() => onMenu?.Invoke());
    }

}
