using System.Collections;
using UnityEngine;

public class CooldownTimer : AbstractConditions
{
    [SerializeField] private SpriteRenderer image;
    [SerializeField] private Color InactiveColor;
    [SerializeField] private Color ActiveColor;
    [SerializeField] private float cooldownTime;

    private void Start()
    {
        Satisfy();
    }

    public void StartCooldown()
    {
        StartCoroutine(cooldown());
    }

    private IEnumerator cooldown()
    {
        UnSatisfy();
        yield return new WaitForSeconds(cooldownTime);
        Satisfy();
    }
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

}
