using UnityEngine;

public class AnimatorSwitchGameObject : AbstractAnimator
{
    [SerializeField] private GameObject originalGameObject;
    [SerializeField] private GameObject secondaryGameObject;
    public override void Animate()
    {
        originalGameObject.SetActive(!originalGameObject.activeInHierarchy);
        secondaryGameObject.SetActive(!secondaryGameObject.activeInHierarchy);
        base.Exit();
    }
}
