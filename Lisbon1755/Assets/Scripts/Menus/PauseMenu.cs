using UnityEngine;

/// <summary>
/// Manage the pause menu.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Checks whether the game is paused.
    /// </summary>
    public static bool GameIsPaused = false;

    /// <summary>
    /// Access the pause menu UI gameobject.
    /// </summary>
    public GameObject pauseMenuUI;

    /// <summary>
    /// Access the LevelLoader script.
    /// </summary>
    [SerializeField]
    private LevelLoader levelLoader;
     
    /// <summary>
    /// To be played in every frame of the game.
    /// Check whether the player wants to pause the game.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Resume the game.
    /// </summary>
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    /// <summary>
    /// Pause the game.
    /// </summary>
    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    /// <summary>
    /// Load the main menu.
    /// </summary>
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        levelLoader.LoadLevel(0);
    }

    /// <summary>
    /// Quit the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
