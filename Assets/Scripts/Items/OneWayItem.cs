
using UnityEngine;

public class OneWayItem : AbstractItem
{
    public override void ObjectExecuted()
    {
        OnObjectExecuted?.Invoke();
        if (AbstractTriger.TryGetComponent<Collider2D>(out Collider2D collider))
        {
            collider.enabled = false;
        }
        else
        {
            AbstractTriger.enabled = false;
        }
    }
}
