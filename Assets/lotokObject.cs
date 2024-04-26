using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lotokObject : MonoBehaviour
{
    [SerializeField] private GameObject red;
    [SerializeField] private GameObject green;
    [SerializeField] private bool isDesireColorRed;
    [SerializeField] private bool isDefouldColorRed;
    [SerializeField] private AbstractItem button;
    [SerializeField] private ScreenLotokController screenLotokController;

    public bool IsOk => isCurrentColorRed == isDesireColorRed;

    private bool isCurrentColorRed;

    private void OnEnable()
    {
        isCurrentColorRed = isDefouldColorRed;
        button.OnObjectExecuted += ChangeColors;
        UpdateColor();
    }

    private void OnDisable()
    {
        button.OnObjectExecuted -= ChangeColors;
    }

    private void UpdateColor()
    {
        if (isCurrentColorRed)
        {
            green.SetActive(false);
            red.SetActive(true);
        }
        else
        {
            red.SetActive(false);
            green.SetActive(true);
        }
    }

    private void ChangeColors()
    {
        isCurrentColorRed = !isCurrentColorRed;
        UpdateColor();
        screenLotokController.CheakForWin();
    }

    internal void Sleep()
    {
        button.OnObjectExecuted -= ChangeColors;
    }
}
