using System;
using UnityEngine;

public class NarratorText : MonoBehaviour
{
    [TextArea][SerializeField] private string unSatisficedText;
    [TextArea][SerializeField] private string satisficedText;
    [SerializeField] private AbstractItem abstractItem;

    private void OnEnable()
    {
        abstractItem.OnConditionNotSatisficed += PlayUnSatisfiedText;
        abstractItem.OnObjectExecuted += PlaySatisfiedText;
    }

    private void OnDisable()
    {
        abstractItem.OnConditionNotSatisficed -= PlayUnSatisfiedText;
        abstractItem.OnObjectExecuted -= PlaySatisfiedText;
    }

    private void PlaySatisfiedText()
    {
        SceneController.Instance.NarratorController.ShowText(satisficedText);
    }

    private void PlayUnSatisfiedText()
    {
        SceneController.Instance.NarratorController.ShowText(unSatisficedText);

    }
}
