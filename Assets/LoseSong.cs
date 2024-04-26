using UnityEngine;

public class LoseSong : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.AudioController.Lose();
    }
}
