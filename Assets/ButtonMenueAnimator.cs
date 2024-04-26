using DG.Tweening;
using UnityEngine;

public class ButtonMenueAnimator : MonoBehaviour
{
    private void Start()
    {
        transform.DOMoveY(transform.position.y + 15f, 3f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }
}
