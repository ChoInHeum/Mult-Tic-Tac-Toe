using DG.Tweening;
using UnityEngine;

public class RotateShake : MonoBehaviour
{
    public float maxShakeAngle = 15f;
    public float maxDuration = 1f;     
    public float maxDelay = 0.5f;      

    void Start()
    {
        float randomAngle = Random.Range(5f, maxShakeAngle); 
        float randomDuration = Random.Range(0.5f, maxDuration);
        float randomDelay = Random.Range(0f, maxDelay);

        transform
            .DOLocalRotate(new Vector3(0, 0, randomAngle), randomDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(randomDelay);
    }
}