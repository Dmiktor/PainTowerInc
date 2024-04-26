using DG.Tweening;
using UnityEngine;

public class ChangeColorAnimator : AbstractAnimator
{
    [SerializeField] Color color;
    [SerializeField] float duration;
    [SerializeField] Ease ease;
    [SerializeField] LoopType loopType = LoopType.Yoyo;
    [SerializeField] int loopCount = 2;
    public override void Animate()
    {
        Item.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer);
        spriteRenderer.DOColor(color, duration).SetEase(ease).SetLoops(loopCount, loopType).OnComplete(base.Exit);
    }

}
