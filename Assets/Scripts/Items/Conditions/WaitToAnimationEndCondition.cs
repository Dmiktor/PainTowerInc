using UnityEngine;

public class WaitToAnimationEndCondition : AbstractConditions
{
    [SerializeField] protected AbstractItem item;
    protected void Start()
    {
        base.Satisfy();
        item.OnObjectExecuted += Satisfy;
        item.OnConditionSatisficed += UnSatisfy;
    }
    private void OnDisable()
    {
        item.OnObjectExecuted -= Satisfy;
        item.OnConditionSatisficed -= UnSatisfy;
    }
}
