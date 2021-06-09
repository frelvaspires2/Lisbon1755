using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main menu controller.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Access the score stats scriptableobject.
    /// </summary>
    [SerializeField]
    private ScoreStats scoreStats;

    /// <summary>
    /// Play the game (starts at level 1).
    /// </summary>
    public void PlayGame()
    {
        scoreStats.Level1Score = default;
        scoreStats.Level2Score = default;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Quit the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
        
}

