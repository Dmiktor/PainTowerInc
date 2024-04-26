using System;
using UnityEngine;

public abstract class AbstractTriger : MonoBehaviour
{
    public Action OnTriger;

    internal void OnTriggered()
    {
        OnTriger?.Invoke();
    }
}
