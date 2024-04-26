using UnityEngine;

public class SounPlayer : MonoBehaviour
{
    [SerializeField] private AbstractTriger abstractTriger;
    [SerializeField] private AbstractItem abstractItem;

    private void OnEnable()
    {

        if (abstractItem != null)
        {
            abstractItem.OnObjectExecuted += PlayLockerSound;
        }
        if (abstractTriger != null)
        {
            abstractTriger.OnTriger += PlayButtonSound;
        }
    }
    private void OnDisable()
    {
        if (abstractItem != null)
        {
            abstractItem.OnObjectExecuted -= PlayLockerSound;
        }
        if (abstractTriger != null)
        {
            abstractTriger.OnTriger -= PlayButtonSound;
        }
    }

    private void PlayButtonSound()
    {
        GameManager.Instance.AudioController.PlayButton();
    }

    private void PlayLockerSound()
    {
        GameManager.Instance.AudioController.OpenLocker();
    }
}
