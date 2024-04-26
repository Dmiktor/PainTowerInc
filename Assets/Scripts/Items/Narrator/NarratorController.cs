using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NarratorController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textField;
    [SerializeField] private float timeSpeed;
    [SerializeField] private int charPerTimeFast;

    private bool textForce = false;

    private Coroutine textCoroutine;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            textForce = true;
            Debug.Log("Now Text Is Fast");
        }
        else
        {
            textForce = false;
            Debug.Log("Now Text Is Slow");
        }
    }

    public void ShowText(string TextToShow)
    {
        textField.text = "";
        textCoroutine = StartCoroutine(TextCoroutine(TextToShow));
    }

    private IEnumerator TextCoroutine(string TextToShow)
    {
        List<char> textChars = new List<char>(TextToShow.ToCharArray());
        while (textChars.Count > 0)
        {
            if (!textForce)
            {
                textField.text += textChars[0];
                textChars.RemoveAt(0);
                yield return new WaitForSeconds(timeSpeed);
            }
            else
            {
                if (textChars.Count > charPerTimeFast)
                {
                    for (int i = 0; i < charPerTimeFast; i++)
                    {
                        textField.text += textChars[0];
                        textChars.RemoveAt(0);
                    }
                }
                else
                {
                    for (int i = 0; i < textChars.Count; i++)
                    {
                        textField.text += textChars[0];
                        textChars.RemoveAt(0);
                    }

                }
                yield return new WaitForSeconds(timeSpeed);
            }
        }
    }

    private void OnDisable()
    {
        if (textCoroutine != null) StopAllCoroutines();
    }
}
