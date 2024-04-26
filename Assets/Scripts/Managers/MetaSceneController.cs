using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class MetaSceneController : MonoBehaviour
{
    [Scene][SerializeField] int targetSceneId;
    [SerializeField] private Button continueButton;

    private void Start()
    {
        continueButton.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        GameManager.Instance.TransitToScene(targetSceneId);
    }
}
