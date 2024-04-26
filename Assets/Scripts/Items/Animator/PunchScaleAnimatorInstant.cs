using DG.Tweening;
using UnityEngine;

public class PunchScaleAnimatorInstant : AbstractAnimator
{
    [SerializeField] private float punchTime;
    [SerializeField] private float elasticity;
    [SerializeField] private int vibrato;
    [SerializeField] private Vector2 punchForce;
    [SerializeField] private Ease ease;
    public override void Animate()
    {
        base.Exit();
        Item.transform.DOPunchScale(punchForce, punchTime, vibrato, elasticity).SetEase(ease);
    }
}
