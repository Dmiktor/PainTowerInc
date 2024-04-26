using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSong : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.AudioController.Win();
    }

}
