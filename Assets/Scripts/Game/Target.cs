using DG.Tweening;
using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public enum BoosterType
{
    None,
    Freezer,
    Doublepoint,
}

public class Target : MonoBehaviour, IPointerClickHandler
{
    public Action<BoosterType> onBoosterClicked;

    private Image image;
    private BoosterType boosterType = BoosterType.None;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, 0.4f).SetEase(Ease.OutBack);
    }

    public void Init(Action<BoosterType> boosterCallback = null, BoosterType type = BoosterType.None)
    {
        boosterType = type;
        onBoosterClicked = boosterCallback;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnHit();
        onBoosterClicked?.Invoke(boosterType);
    }

    public void OnHit()
    {
        if (image == null) return;

        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOScale(1.2f, 0.1f));
        seq.Append(transform.DOScale(0f, 0.2f));
        seq.Join(image.DOFade(0f, 0.2f));
        seq.OnComplete(() =>
        {
            DOTween.Kill(transform);
            DOTween.Kill(image);
            Destroy(gameObject);
        });
    }
}
