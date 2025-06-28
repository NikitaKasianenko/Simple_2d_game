using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEffect : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RectTransform effectPrefab;

    private RectTransform spawnZone;

    private void Awake()
    {
        spawnZone = GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.Instance.PlaySFX(GameConfigProvider.Instance.Sounds.missClick);
        Vector2 localPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                spawnZone,
                eventData.position,
                eventData.pressEventCamera,
                out localPos))
        {
            var effect = Instantiate(effectPrefab, spawnZone);
            effect.anchoredPosition = localPos;

            effect.localScale = Vector3.zero;
            effect.DOScale(1f, 0.2f).SetEase(Ease.OutBack)
                .OnComplete(() =>
                {
                    effect.DOScale(0f, 0.3f).SetDelay(0.2f).OnComplete(() =>
                    {
                        Destroy(effect.gameObject);
                    });
                });
        }
    }
}
