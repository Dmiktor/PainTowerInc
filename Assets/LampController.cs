using UnityEngine;

public class LampController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer leftLamp;
    [SerializeField] private SpriteRenderer rightLamp;

    [SerializeField] private AbstractItem triggerButton;
    [SerializeField] private AbstractItem rightLampLocker;
    [SerializeField] private AbstractItem leftLampLocker;

    [SerializeField] private Material redMaterial;
    [SerializeField] private Material greenMaterial;

    [SerializeField] private EternalContion leftDrawerEternalConditionla;
    [SerializeField] private EternalContion rigthtDrawerEternalConditionla;



    private bool isRightLampRed = true;
    private bool isLeftLampRed = false;

    private bool isRightLampLocked = false;
    private bool isLeftLampLocked = false;

    private void OnEnable()
    {
        triggerButton.OnObjectExecuted += SwitchLamps;
        leftLampLocker.OnObjectExecuted += SwitchLockLeftLamp;
        rightLampLocker.OnObjectExecuted += SwitchLockRightLamp;
    }

    private void OnDisable()
    {
        triggerButton.OnObjectExecuted -= SwitchLamps;
        leftLampLocker.OnObjectExecuted -= SwitchLockLeftLamp;
        rightLampLocker.OnObjectExecuted -= SwitchLockRightLamp;
    }

    private void SwitchLamps()
    {
        if (!isLeftLampLocked)
        {
            isLeftLampRed = !isLeftLampRed;
        }
        if (!isRightLampLocked)
        {
            isRightLampRed = !isRightLampRed;
        }
        UpdateLamps();

        if (isLeftLampRed && isRightLampRed)
        {
            leftDrawerEternalConditionla.HardSatisfy();
        }
        else
        {
            leftDrawerEternalConditionla.HardUnSatisfy();
        }

        if (!isLeftLampRed && !isRightLampRed)
        {
            rigthtDrawerEternalConditionla.HardSatisfy();
        }
        else
        {
            rigthtDrawerEternalConditionla.HardUnSatisfy();
        }
    }

    private void UpdateLamps()
    {
        if (isLeftLampRed)
        {
            leftLamp.material = redMaterial;
        }
        else
        {
            leftLamp.material = greenMaterial;
        }

        if (isRightLampRed)
        {
            rightLamp.material = redMaterial;
        }
        else
        {
            rightLamp.material = greenMaterial;
        }
    }

    private void SwitchLockLeftLamp()
    {
        isLeftLampLocked =! isLeftLampLocked;
    }

    private void SwitchLockRightLamp()
    {
        isRightLampLocked = !isRightLampLocked;
    }
}
