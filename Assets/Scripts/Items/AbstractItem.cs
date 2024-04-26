using System;
using UnityEngine;

public abstract class AbstractItem : MonoBehaviour
{
    [SerializeField] private AbstractTriger abstractTriger;
    [SerializeField] private AbstractAnimator abstractAnimator;
    [SerializeField] private AbstractConditions abstractConditions;

    public Action OnObjectExecuted;
    public Action OnConditionSatisficed;
    public Action OnConditionNotSatisficed;

    protected AbstractTriger AbstractTriger => abstractTriger;
    protected AbstractAnimator AbstractAnimator => abstractAnimator;
    protected AbstractConditions AbstractConditions => abstractConditions;

    public virtual void Init()
    {
        abstractTriger.OnTriger += ExecuteObject;
        abstractAnimator.OnAnimationExit += ObjectExecuted;
        abstractAnimator.Init(this);
    }

    public virtual void ExecuteObject()
    {
        if (abstractConditions == null || abstractConditions.IsSatisfied)
        {
            OnConditionSatisficed?.Invoke();
            abstractTriger.OnTriger -= ExecuteObject;
            abstractAnimator.Animate();
        }
        else
        {
            OnConditionNotSatisficed?.Invoke();
        }
    }

    public virtual void ObjectExecuted()
    {
        abstractTriger.OnTriger += ExecuteObject;
        OnObjectExecuted?.Invoke();
    }

    public virtual void Exit()
    {
        abstractTriger.OnTriger -= ExecuteObject;
        abstractAnimator.OnAnimationExit -= ObjectExecuted;
    }

    private void OnDisable()
    {
        Exit();
    }
}
