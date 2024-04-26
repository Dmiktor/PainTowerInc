using UnityEngine;

public class StorageController : MonoBehaviour
{
    [SerializeField] private FormController[] forms;
    [SerializeField] private GameObject storageO;

    public void CheakFormForWin()
    {
        bool ok = true;
        for (int i = 0; i < forms.Length; i++)
        {
           if (!forms[i].IsOk)
            {
                ok = false;
            }
        }
        if (ok)
        {
            for (int i = 0; i < forms.Length; i++)
            {
                forms[i].Sleep();
            }
            GameManager.Instance.AudioController.OpenLocker();
            storageO.SetActive(true);
        }
    }
}
