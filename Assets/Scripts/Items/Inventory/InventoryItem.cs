using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerClickHandler
{
    
    private InventorySlot currentSlot;

    [SerializeField] private int id;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Image image;

    [SerializeField] private float moveTime;
    [SerializeField] private Ease easeX = Ease.InOutCubic;
    [SerializeField] private Ease easeY = Ease.InOutCubic;

    private InventoryNote note;
    private bool draggable;

    public int Id => id;
    public RectTransform RectTransform => rectTransform;

    public void Init()
    {
        note = SceneController.Instance.NoteManager.TryFindNodeById(id);
    }
    internal void PlayReturnAnimation(InventorySlot currentSlot)
    {
        draggable = false;
        this.currentSlot = currentSlot;
        currentSlot.PlaceItem();
        rectTransform.DOAnchorPosX(0, moveTime, true).SetEase(easeX);
        rectTransform.DOAnchorPosY(0, moveTime, true).SetEase(easeY).OnComplete(() => { currentSlot.Bounce(); draggable = true;});
    }

    public void UpdateCurrentSlot(InventorySlot newSlot)
    {
        currentSlot.TakeItem();
        currentSlot = newSlot;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!draggable)
            return;
        draggable = false;
        transform.SetParent(SceneController.Instance.MainUiReact);
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
            transform.position = eventData.position;
    }
   
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(currentSlot.transform);
        PlayReturnAnimation(currentSlot);
        image.raycastTarget = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!draggable)
        {
            return;
        }
        if (note != null)
        {
            note.Display();
        }
    }

    internal void OnDraggedToTrigger()
    {
        currentSlot.TakeItem();
        currentSlot = SceneController.Instance.InventoryController.HideSlot;
        gameObject.SetActive(false);
    }
}
