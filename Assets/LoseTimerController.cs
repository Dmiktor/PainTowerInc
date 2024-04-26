using DG.Tweening;
using System.Collections;
using UnityEngine;

public class LoseTimerController : MonoBehaviour
{
    [SerializeField] private MiniGameController miniGameController;

    [SerializeField] private Transform loseTimerTransform;
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;
    [SerializeField] private float timeStep;
    [SerializeField] private float secondsToEndGame;

    [SerializeField] private float timeToResetPositionOfTimer = 0.5f;
    [SerializeField] private Ease ease = Ease.OutBounce;


    private float currentTime;

    private Coroutine timerCoroutine;

    public void Init()
    {
        timerCoroutine = StartCoroutine(TimerCoroutine());
        miniGameController.Init();
        miniGameController.OnSuccess += DecreaseCurrentTime;
    }

    private void DecreaseCurrentTime()
    {
        StopCoroutine(timerCoroutine);
        currentTime = 0;
        loseTimerTransform.DOMove(startPosition.position, timeToResetPositionOfTimer).SetEase(ease).OnComplete(() => { timerCoroutine = StartCoroutine(TimerCoroutine()); });
    }

    private IEnumerator TimerCoroutine()
    {
        currentTime = 0; 
        while (currentTime <= secondsToEndGame)
        {
            loseTimerTransform.position = GetNewPosition();
            currentTime += timeStep;
            yield return new WaitForSeconds(timeStep);
        }
        SceneController.Instance.Lose();
    }

    private Vector3 GetNewPosition()
    {
        return ((endPosition.position - startPosition.position) / secondsToEndGame * currentTime) + startPosition.position;
    }

    private void OnDisable()
    {
        StopCoroutine(timerCoroutine);
        miniGameController.OnSuccess -= DecreaseCurrentTime;
    }
}
