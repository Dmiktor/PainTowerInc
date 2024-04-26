using System.Collections;
using UnityEngine;

public class EternalContion : AbstractConditions
{
    [SerializeField] private SpriteRenderer image;
    [SerializeField] private Color InactiveColor;
    [SerializeField] private Color ActiveColor;

    protected override void UnSatisfy()
    {
        base.UnSatisfy();
        image.color = InactiveColor;
    }

    protected override void Satisfy()
    {
        base.Satisfy();
        image.color = ActiveColor;
    }

    public virtual void HardUnSatisfy()
    {
        UnSatisfy();
    }

    public virtual void HardSatisfy()
    {
        Satisfy();
    }

}
