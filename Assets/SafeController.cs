using System;
using UnityEditor;
using UnityEngine;

public class SafeController : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteHolder;
    [SerializeField] private SpriteRenderer spriteRenderer1;
    [SerializeField] private SpriteRenderer spriteRenderer2;
    [SerializeField] private SpriteRenderer spriteRenderer3;

    [SerializeField] private AbstractItem numberItem1;
    [SerializeField] private AbstractItem numberItem2;
    [SerializeField] private AbstractItem numberItem3;

    [SerializeField] private AbstractItem cheakForWinButton;

    [SerializeField] private Transform door;
    [SerializeField] private Transform funFlashDrive;

    [SerializeField] private int targetNumber1 = 6;
    [SerializeField] private int targetNumber2 = 1;
    [SerializeField] private int targetNumber3 = 7;


    private int number1 = 1;
    private int number2 = 1;
    private int number3 = 1;

    private int failCounter = 0;


    void Start()
    {
        numberItem1.OnObjectExecuted += Number1Change;
        numberItem2.OnObjectExecuted += Number2Change;
        numberItem3.OnObjectExecuted += Number3Change;
        cheakForWinButton.OnObjectExecuted += CheakForWinCondition;
    }

    private void CheakForWinCondition()
    {
        if (number1 == targetNumber1 && number2 == targetNumber2 && number3 == targetNumber3) 
        {
            door.gameObject.SetActive(false);
            funFlashDrive.gameObject.SetActive(true);
        }
        else
        {
            failCounter++;
            if (failCounter >= 3)
            {
                SceneController.Instance.Lose();
            }
        }
        GameManager.Instance.AudioController.OpenLocker();
    }

    void Number1Change() {
        number1++;
        if (number1  == 10)
        {
            number1 = 1;
        }
        AdjustNumber(spriteRenderer1, number1);
    }
    void Number2Change() {
        number2++;
        if (number2 == 10)
        {
            number2 = 1;
        }
        AdjustNumber(spriteRenderer2, number2);
    }
    void Number3Change() {
        number3++;
        if (number3 == 10)
        {
            number3 = 1;
        }
        AdjustNumber(spriteRenderer3, number3);
    }

    void AdjustNumber(SpriteRenderer spriteRenderer, int newNumber)
    {
        spriteRenderer.sprite = spriteHolder[newNumber - 1];
    }

    // Update is called once per frame
    void OnDisable()
    {
        numberItem1.OnObjectExecuted -= Number1Change;
        numberItem2.OnObjectExecuted -= Number2Change;
        numberItem3.OnObjectExecuted -= Number3Change;
        cheakForWinButton.OnObjectExecuted -= CheakForWinCondition;
    }
}
