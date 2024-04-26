using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{

    [Scene][SerializeField] int mainMenuSceneId;

    [SerializeField] LoadingScreenController loadingScreenController;
    [SerializeField] AudioController audioController;

    public AudioController AudioController => audioController;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(mainMenuSceneId);
        loadingScreenController.Init();
    }

    public void TransitToScene(int SceneId)
    {
        loadingScreenController.Hide(LoadScene);
        void LoadScene()
        {
            DOTween.KillAll();
            SceneManager.LoadScene(SceneId);
            
        }
    }
}
