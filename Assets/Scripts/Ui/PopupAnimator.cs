using DG.Tweening;
using UnityEngine;

public class PopupAnimator : MonoBehaviour
{

    private RectTransform windowPanel;

    private void Awake()
    {
        windowPanel = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        windowPanel.localScale = Vector3.zero;

        windowPanel.DOScale(1f, 0.5f).SetEase(Ease.OutBack);
    }
}
