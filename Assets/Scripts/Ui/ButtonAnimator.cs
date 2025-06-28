using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 originalScale;
    private Tween currentTween;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AnimateScale(originalScale * 1.1f, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        AnimateScale(originalScale, 0.2f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AnimateScale(originalScale * 0.9f, 0.1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        AnimateScale(originalScale * 1.1f, 0.1f);
    }

    private void AnimateScale(Vector3 targetScale, float duration)
    {
        currentTween?.Kill();
        currentTween = transform.DOScale(targetScale, duration).SetEase(Ease.OutBack);
    }
}
