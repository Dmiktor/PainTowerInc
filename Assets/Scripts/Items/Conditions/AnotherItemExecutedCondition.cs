using UnityEngine;

public class AnotherItemExecutedCondition : AbstractConditions
{
    [SerializeField] private AbstractItem item;
    private void OnEnable()
    {
        item.OnObjectExecuted += Satisfy;
    }
    private void OnDisable()
    {
        item.OnObjectExecuted -= Satisfy;
    }
}
