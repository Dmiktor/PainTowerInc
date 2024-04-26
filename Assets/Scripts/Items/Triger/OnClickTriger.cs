using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OnClickTriger : AbstractTriger
{
    private void OnMouseDown()
    {
        OnTriggered();
    }
}
