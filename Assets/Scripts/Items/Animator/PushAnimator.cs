using DG.Tweening;
using UnityEngine;

public class PushAnimator : AbstractAnimator
{
    [SerializeField] private float shakeStrength;
    [SerializeField] private float shakeDuration = 0.1f;
    [SerializeField] private int vibrato = 1;
    [SerializeField] private Ease ease = Ease.InOutCubic;

    public override void Animate()
    {
        Item.transform.DOShakePosition(shakeDuration, shakeStrength, vibrato).SetEase(ease).OnComplete(Exit);
    }
}
