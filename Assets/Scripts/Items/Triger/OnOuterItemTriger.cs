using UnityEngine;

public class OnOuterItemTriger : AbstractTriger
{
    [SerializeField] private AbstractItem tigerItem;

    private void Start()
    {
        tigerItem.OnObjectExecuted += OnTriggered;
    }

    private void OnDisable()
    {
        tigerItem.OnObjectExecuted -= OnTriggered;
    }
}
