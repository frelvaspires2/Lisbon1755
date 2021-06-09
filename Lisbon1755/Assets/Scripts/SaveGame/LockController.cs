using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Control the lock in the main menu.
/// </summary>
public class LockController : MonoBehaviour
{
    /// <summary>
    /// Lock UI.
    /// </summary>
    [SerializeField]
    private GameObject[] lockUI;

    /// <summary>
    /// Access the load game script.
    /// </summary>
    [SerializeField]
    private LoadGame loadGame;

    /// <summary>
    /// To be played in the first frame of the game.
    /// </summary>
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

    /// <summary>
    /// Check if level 2 is unlocked. If so, load the score from level 1.
    /// </summary>
    public void PlayLevel2()
    {
        if (!lockUI[0].activeSelf)
        {
            loadGame.LoadTheGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

    /// <summary>
    /// Play level 1.
    /// </summary>
    public void PlayLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
