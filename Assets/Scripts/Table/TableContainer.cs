using System;
using UnityEngine;
using UnityEngine.UI;

public class TableContainer : MonoBehaviour
{
    [SerializeField] private TableAnimator tableAnimator;

    [SerializeField] private Transform table;
    [SerializeField] private Transform[] tablePositionStack;
    
    [SerializeField] private Button toRightButton;
    [SerializeField] private Button toLeftButton;

    private int currentTablePosition = 2;

    public void Init()
    {
        tableAnimator.Init();
        HardSetToPositions();
        toRightButton.onClick.AddListener(TransferToRight);
        toLeftButton.onClick.AddListener(TransferToLeft);
    }

    private void HardSetToPositions()
    {
        table.transform.position = tablePositionStack[currentTablePosition].position;
    }

    private void TransferToRight()
    {
        currentTablePosition--;
        TransferTable();
    }
    private void TransferToLeft()
    {
        currentTablePosition++;
        TransferTable();
    }

    private void TransferTable()
    {
        tableAnimator.SetNewTablesPositions(table, tablePositionStack[currentTablePosition]);
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        if (currentTablePosition == tablePositionStack.Length - 1)
        {
            toLeftButton.gameObject.SetActive(false);
        }
        else
        {
            toLeftButton.gameObject.SetActive(true);
        }
        if (currentTablePosition == 0)

        {
            toRightButton.gameObject.SetActive(false);
        }
        else
        {
            toRightButton.gameObject.SetActive(true);
        }
    }
}
