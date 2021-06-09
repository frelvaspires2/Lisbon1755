using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] lockUI;

    [SerializeField]
    private LoadGame loadGame;

    private void Start()
    {
        if (loadGame.CheckIfLevel2IsUnlocked())
        {
            lockUI[0].SetActive(false);
        }
        else
        {
            lockUI[0].SetActive(true);
        }
    }
}
