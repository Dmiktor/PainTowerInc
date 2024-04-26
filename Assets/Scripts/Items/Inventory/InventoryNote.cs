using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryNote : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image noteImage;
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeTarget;
    [SerializeField] private float appearTime;
    [SerializeField] private float hideTime;
    [SerializeField] private float fadeTime;
    [SerializeField] private float punchPower = 15f;
    [SerializeField] private Ease ease;

    [SerializeField] private int id;

    public int Id => id;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (noteImage.IsActive())
        {
            noteImage.transform.DOPunchPosition(Vector2.up * punchPower, hideTime, 1, 1).OnComplete(()=>{ noteImage.gameObject.SetActive(false); }).SetEase(ease);
            fadeImage.DOFade(0, fadeTime).OnComplete(() => { fadeImage.gameObject.SetActive(false); }).SetEase(ease);
        }
    }

    internal void Display()
    {
        noteImage.gameObject.SetActive(true);
        fadeImage.gameObject.SetActive(true);
        noteImage.transform.DOPunchPosition(Vector2.up * punchPower, appearTime, 1, 1).SetEase(ease);
        fadeImage.DOFade(fadeTarget, fadeTime).SetEase(ease);

    }

}
