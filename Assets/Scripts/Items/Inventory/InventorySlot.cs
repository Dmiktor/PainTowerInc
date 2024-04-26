using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private Vector2 punchStrength = Vector2.up;
    [SerializeField]
    private float punchDuration = 0.5f;
    [SerializeField]
    private Ease ease = Ease.InOutCubic;

    [SerializeField]
    private RectTransform rectTransform;

    private bool isEmpty = true;
    public bool IsEmpty => isEmpty;
    public RectTransform RectTransform => rectTransform;



    internal void Init()
    {
    }

    internal void PlaceItem()
    {
        isEmpty = false;
    }

    public void TakeItem()
    {
        isEmpty = true;
    }

    public void Bounce()
    {
        transform.DOPunchPosition(punchStrength, punchDuration, 1).SetEase(ease);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!IsEmpty)
        {
            return;
        }
        InventoryItem draggableItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (draggableItem != null)
        {
            draggableItem.UpdateCurrentSlot(this);
        }
    }

}
