using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private InventoryNote[] notes;
    public void DoStart()
    {
        for (int i = 0; i < notes.Length; i++)
        {
            notes[i].gameObject.SetActive(false);
        }
    }
    internal InventoryNote TryFindNodeById(int id)
    {
        InventoryNote note = null;
        for (int i = 0; i < notes.Length; i++)
        {
            if (notes[i].Id == id)
            {
                note = notes[i];
            }
        }
        return note;
    }
}
