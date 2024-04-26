using NaughtyAttributes;
using System;
using UnityEngine;

public class SceneController : MonoSingleton<SceneController>
{
    [SerializeField] private TableContainer tableContainer;
    [SerializeField] private ItemsController itemsController;
    [SerializeField] private InventoryController inventoryController;
    [SerializeField] private RectTransform mainUiReact;
    [SerializeField] private NoteManager noteManager;
    [SerializeField] private LoseTimerController loseTimerController;
    [SerializeField] private NarratorController narratorController;

    [Scene][SerializeField] private int winScene;
    [Scene][SerializeField] private int loseScene;

    public InventoryController InventoryController => inventoryController;
    public RectTransform MainUiReact => mainUiReact;
    public NoteManager NoteManager => noteManager;
    public NarratorController NarratorController => narratorController;

    internal void Lose()
    {
        GameManager.Instance.TransitToScene(loseScene);
    }

    internal void Win()
    {
        GameManager.Instance.TransitToScene(winScene);
    }

    private void Start()
    {
        tableContainer.Init();
        itemsController.Init();
        loseTimerController.Init();
    }
}
