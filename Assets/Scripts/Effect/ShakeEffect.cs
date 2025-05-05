using DG.Tweening;
using UnityEngine;

public class RotateShake : MonoBehaviour
{
    public float maxShakeAngle = 15f;  // 최대 회전 각도
    public float maxDuration = 1f;     // 한쪽으로 흔들리는 최대 시간
    public float maxDelay = 0.5f;      // 시작 지연 시간

    void Start()
    {
        // 랜덤하게 흔들리기
        float randomAngle = Random.Range(5f, maxShakeAngle);  // 각도 범위
        float randomDuration = Random.Range(0.5f, maxDuration); // 시간 범위
        float randomDelay = Random.Range(0f, maxDelay); // 지연 시간

        // Z축 기준으로 랜덤한 회전 각도로 흔들기
        transform
            .DOLocalRotate(new Vector3(0, 0, randomAngle), randomDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(randomDelay);  // 지연 시간 적용
    }
}