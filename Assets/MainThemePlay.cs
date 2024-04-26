using UnityEngine;

public class MainThemePlay : MonoBehaviour
{
    void OnEnable()
    {
        GameManager.Instance.AudioController.Main();
    }
}
