using System;
using UnityEngine;

public abstract class AbstractAnimator : MonoBehaviour
{
    public Action OnAnimationExit;
    private AbstractItem item;
    protected AbstractItem Item => item;

    public virtual void Init(AbstractItem item)
    {
        this.item = item;
    }
    public abstract void Animate();
    public virtual void Exit()
    {
        OnAnimationExit?.Invoke();
    }
}
