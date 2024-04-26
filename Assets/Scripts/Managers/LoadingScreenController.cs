using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenController : MonoBehaviour
{
    [SerializeField] private Ease movingEase;
    [SerializeField] private float timeToOpen;
    [SerializeField] private RectTransform hidePosition;
    [SerializeField] private RectTransform showPosition;
    [SerializeField] private RectTransform doorTransform;

    [Scene][SerializeField] private int sceneToIgnore;


    public void Init()
    {
        DontDestroyOnLoad(gameObject);
        doorTransform.anchoredPosition = hidePosition.anchoredPosition;
       SceneManager.sceneLoaded += Show;
    }

    private void Show(Scene scene, LoadSceneMode loadMode)
    {
        if (sceneToIgnore == scene.buildIndex) return;
        doorTransform.DOAnchorPos(showPosition.anchoredPosition, timeToOpen).SetEase(movingEase);


    }

    public void Hide(System.Action loadScene)
    {
        doorTransform.DOAnchorPos(hidePosition.anchoredPosition, timeToOpen).SetEase(movingEase).OnComplete(loadScene.Invoke);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= Show;
    }
}
