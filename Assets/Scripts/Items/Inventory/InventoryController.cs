using UnityEngine;

public class InventoryController : MonoBehaviour
{
   [SerializeField] private InventorySlot[] inventorySlots;
    [SerializeField] private InventorySlot hideSlot;
    public InventorySlot HideSlot => hideSlot;
   public void Init()
    {
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].Init();
        }
    }

    public InventorySlot TryToFindFirstAvailableSlot()
    {
        InventorySlot inventorySlot = null;
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].IsEmpty)
            {
                inventorySlot = inventorySlots[i];
                break;
            }
        }
        return inventorySlot;
    }
}
