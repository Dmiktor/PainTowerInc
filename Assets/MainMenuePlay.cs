using UnityEngine;

public class MainMenuePlay : MonoBehaviour
{
    private void OnEnable()
    {
    GameManager.Instance.AudioController.Menue(); 
    }
}
