using System;
using UnityEngine;

public class FormController : MonoBehaviour
{
    [SerializeField] private StorageController CheakFormForWin;
    [SerializeField] private SpriteRenderer targetSprite;
    [SerializeField] private Sprite[] spritePool;
    [SerializeField] private Color[] colorPool;

    [SerializeField] private int colorByDefolt;
    [SerializeField] private int shapeByDefolt;

    [SerializeField] private AbstractItem changeForm;
    [SerializeField] private AbstractItem changeColor;

    [SerializeField] private int desierSprite;
    [SerializeField] private int desierColor;

    private int currentSprite;
    private int currentColor;

    public bool IsOk => currentSprite == desierSprite && currentColor == desierColor;

    private void OnEnable()
    {
        changeColor.OnObjectExecuted += ChangeColor;
        changeForm.OnObjectExecuted += ChangeShape;
        currentColor = colorByDefolt;
        currentSprite = shapeByDefolt;
        UpdateColor();
        UpdateShape();
    }

    private void UpdateShape()
    {
        targetSprite.sprite = spritePool[currentSprite];
    }

    private void UpdateColor()
    {
        targetSprite.color = colorPool[currentColor];
    }

    private void ChangeShape()
    {
        currentSprite++;
        if (currentSprite == spritePool.Length)
        {
            currentSprite = 0;
        }
        UpdateShape();
        CheakFormForWin.CheakFormForWin();
    }

    private void ChangeColor()
    {
        currentColor++;
        if (currentColor == colorPool.Length)
        {
            currentColor = 0;
        }
        UpdateColor();
        CheakFormForWin.CheakFormForWin();
    }

    internal void Sleep()
    {
        changeColor.OnObjectExecuted -= ChangeColor;
        changeForm.OnObjectExecuted -= ChangeShape;
    }

    private void OnDisable()
    {
        changeColor.OnObjectExecuted -= ChangeColor;
        changeForm.OnObjectExecuted -= ChangeShape;
    }
}
