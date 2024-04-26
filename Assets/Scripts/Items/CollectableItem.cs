using UnityEngine;

public class CollectableItem : AbstractItem
{
    [SerializeField] private InventoryItem inventoryItemPrefab; 
    public override void ObjectExecuted()
    {
         InventorySlot targetInventorySlot;
        targetInventorySlot = SceneController.Instance.InventoryController.TryToFindFirstAvailableSlot();

        if (targetInventorySlot != null)
        {
            InventoryItem newInventoryItemPrefab = Instantiate(inventoryItemPrefab, SceneController.Instance.MainUiReact);
            newInventoryItemPrefab.Init();

            Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(transform.position);
            Vector2 WorldObject_ScreenPosition = new Vector2(
            ((ViewportPosition.x * SceneController.Instance.MainUiReact.sizeDelta.x) - (SceneController.Instance.MainUiReact.sizeDelta.x * 0.5f)),
            ((ViewportPosition.y * SceneController.Instance.MainUiReact.sizeDelta.y) - (SceneController.Instance.MainUiReact.sizeDelta.y * 0.5f)));


            newInventoryItemPrefab.RectTransform.anchoredPosition = WorldObject_ScreenPosition;
            newInventoryItemPrefab.transform.SetParent(targetInventorySlot.transform);
            newInventoryItemPrefab.PlayReturnAnimation(targetInventorySlot);

            Exit();
            gameObject.SetActive(false);
        }
        else
        {
            AbstractTriger.OnTriger += ExecuteObject;
        }
    }
    public override void Exit()
    {
        
    }
}
