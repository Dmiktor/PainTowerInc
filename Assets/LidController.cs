using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidController : MonoBehaviour
{
    [SerializeField] private AbstractItem red;
    [SerializeField] private AbstractItem green;
    [SerializeField] private AbstractItem blue;

    [SerializeField] private GameObject toCloase;
    [SerializeField] private GameObject toOpen;
    [SerializeField] private GameObject toOpen2;
    [SerializeField] private BoxCollider2D toEnable;


    bool redT = false;
    bool greenT = false;
    bool blueT = false;

    private void OnEnable()
    {
        red.OnObjectExecuted += CheakForEndRed;
        blue.OnObjectExecuted += CheakForEndBlue;
        green.OnObjectExecuted += CheakForEndGreen;
    }

    private void OnDisable()
    {
        red.OnObjectExecuted -= CheakForEndRed;
        blue.OnObjectExecuted -= CheakForEndBlue;
        green.OnObjectExecuted -= CheakForEndGreen;
    }

    private void CheakForEndGreen()
    {
        greenT = true;
        CheakForWin();
    }

    private void CheakForWin()
    {
        if (redT & blueT & greenT)
        {
            toCloase.SetActive(false);
            toOpen.SetActive(true);
            toOpen2.SetActive(true);
            toEnable.enabled = true;
        }
    }

    private void CheakForEndBlue()
    {
        blueT = true;
        CheakForWin();
    }

    private void CheakForEndRed()
    {
        redT = true;
        CheakForWin();
    }
}
