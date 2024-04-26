using DG.Tweening;
using NaughtyAttributes;
using System;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    public Action OnSuccess;

    [SerializeField] private AbstractItem startMiniGameButton;
    [SerializeField] private AbstractItem endMiniGameButton;
    [SerializeField] private CooldownTimer cooldownForStartButton;
    [SerializeField] private EternalContion miniGameButtonCondition;


    [SerializeField] private Transform winingBlock;
    [SerializeField] private Transform targetBlock;
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;
    

    [SerializeField] private float winingBlockHalfLength;

    [SerializeField] private float cycleTime;
    [SerializeField] private float toPositionTime = 0.2f;

    internal void Init()
    {
        miniGameButtonCondition.HardUnSatisfy();
        startMiniGameButton.OnObjectExecuted += StartMiniGame;
    }

    private void StartMiniGame()
    {
        cooldownForStartButton.HardUnSatisfy();
        targetBlock.DOLocalMove(startPosition.localPosition, toPositionTime).SetEase(Ease.InOutQuart);
        winingBlock.DOLocalMove(new Vector2(UnityEngine.Random.Range(startPosition.localPosition.x + winingBlockHalfLength, endPosition.localPosition.x - winingBlockHalfLength), winingBlock.localPosition.y), toPositionTime).SetEase(Ease.InOutQuart).OnComplete(() =>
        {
            targetBlock.DOLocalMove(endPosition.localPosition, cycleTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
            endMiniGameButton.OnObjectExecuted += EndMiniGame;
            miniGameButtonCondition.HardSatisfy();
        });
    }

    private void EndMiniGame()
    {
        endMiniGameButton.OnObjectExecuted -= EndMiniGame;
        targetBlock.DOKill();
        cooldownForStartButton.StartCooldown();
        if (MathF.Abs(targetBlock.localPosition.x - winingBlock.localPosition.x) < winingBlockHalfLength)
        {
            OnSuccess?.Invoke();
        }
        miniGameButtonCondition.HardUnSatisfy();
    }
}
