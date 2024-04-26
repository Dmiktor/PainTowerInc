using UnityEngine;

public class ItemsController : MonoBehaviour
{

    [SerializeField] private AbstractItem[] items;
    public void Init()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].Init();
        }
    }

}
