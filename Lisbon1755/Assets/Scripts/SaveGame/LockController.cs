using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void PlayLevel2()
    {
        if (!lockUI[0].activeSelf)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
