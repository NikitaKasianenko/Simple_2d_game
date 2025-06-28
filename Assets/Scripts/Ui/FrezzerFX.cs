using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FrezzerFX : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float targetAlpha = 0.5f;
    private float stayTime = 0.5f;

    private void Start()
    {
        stayTime = GameConfigProvider.Instance.Economy.freezeTime;
    }


    public void PlayFade()
    {

        fadeImage.DOFade(targetAlpha, GameConfigProvider.Instance.Economy.freezeTime).OnComplete(() =>
        {
            DOVirtual.DelayedCall(stayTime, () =>
            {
                fadeImage.DOFade(0f, GameConfigProvider.Instance.Economy.freezeTime);
            });
        });
    }
}
