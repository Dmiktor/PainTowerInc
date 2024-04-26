using UnityEngine;

public class ScreenLotokController : MonoBehaviour
{
    [SerializeField] private lotokObject[] lotokObjects;
    [SerializeField] private GameObject target;

    public void CheakForWin()
    {
        bool ok = true;
        for (int i = 0; i < lotokObjects.Length; i++)
        {
            if (!lotokObjects[i].IsOk) 
            {
                ok = false;
            }
        }    
        if (ok)
        {
            target.SetActive(true);
            for (int i = 0; i < lotokObjects.Length; i++)
            {
                lotokObjects[i].Sleep();
            }
        }
    }
}
