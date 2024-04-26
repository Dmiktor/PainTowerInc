using UnityEngine;

public class ItemWin : AbstractItem
{
    public override void ExecuteObject()
    {
        SceneController.Instance.Win();
    }
}
