using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ShakeBounce_ButtonEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float shakeAngle = 15f;
    public float shakeDuration = 0.2f;
    public float bounceScale = 1.2f;
    public float bounceDuration = 0.15f;

    private RectTransform rectTransform;
    private Tween shakeTween;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rectTransform.DOKill();

        rectTransform.localRotation = Quaternion.Euler(0, 0, -shakeAngle);

        shakeTween = rectTransform
            .DOLocalRotate(new Vector3(0, 0, shakeAngle), shakeDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (shakeTween != null && shakeTween.IsActive())
        {
            shakeTween.Kill();
        }

        // 튕기는 스케일 효과
        Sequence seq = DOTween.Sequence();
        seq.Append(rectTransform.DOScale(bounceScale, bounceDuration).SetEase(Ease.OutBack));
        seq.Append(rectTransform.DOScale(1f, bounceDuration).SetEase(Ease.InSine));
        seq.Join(rectTransform.DOLocalRotate(Vector3.zero, 0.1f)); // 회전 원복
    }
}