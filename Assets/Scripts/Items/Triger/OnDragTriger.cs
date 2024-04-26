using UnityEngine;
using UnityEngine.EventSystems;

public class OnDragTriger : AbstractTriger, IDropHandler
{
    [SerializeField] private int targetItemId;
    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem draggableItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (draggableItem != null)
        {
            if (draggableItem.Id == targetItemId)
            {
                draggableItem.OnDraggedToTrigger();
                base.OnTriggered();
            }
        }
    }

}
