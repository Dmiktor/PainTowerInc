using UnityEngine;

public abstract class AbstractConditions : MonoBehaviour
{
    private bool isSatisfied = false;

    public bool IsSatisfied { get { return isSatisfied; } }

    protected virtual void Satisfy()
    {
        isSatisfied = true;
    }
    protected virtual void UnSatisfy()
    {
        isSatisfied = false;
    }
}
