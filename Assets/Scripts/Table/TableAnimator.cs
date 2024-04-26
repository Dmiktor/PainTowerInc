using DG.Tweening;
using UnityEngine;

public class TableAnimator : MonoBehaviour
{
    [SerializeField] float moveTime;
    [SerializeField] Ease moveEase;

    public void Init()
    {
    }

    internal void SetNewTablesPositions(Transform table, Transform transform)
    {
        table.DOMoveX(transform.position.x, moveTime).SetEase(moveEase);
    }
}
