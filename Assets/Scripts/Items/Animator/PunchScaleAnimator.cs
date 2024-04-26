using DG.Tweening;
using UnityEngine;
public class PunchScaleAnimator : AbstractAnimator
{
    [SerializeField] private float punchTime;
    [SerializeField] private float elasticity;
    [SerializeField] private int vibrato;
    [SerializeField] private Vector2 punchForce;
    [SerializeField] private Ease ease;
    private Vector3 localScaleTarget;

    public override void Init(AbstractItem item)
    {
        base.Init(item);
        localScaleTarget = item.transform.localScale;
    }
    public override void Animate()
    {
        Item.transform.localScale = localScaleTarget;
        Item.transform.DOPunchScale(punchForce, punchTime, vibrato, elasticity).SetEase(ease).OnComplete(base.Exit);
    }
}
