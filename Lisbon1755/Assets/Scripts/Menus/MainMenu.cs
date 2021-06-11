using UnityEngine;

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
    /// Access the LevelLoader script.
    /// </summary>
    [SerializeField]
    private LevelLoader levelLoader;

    /// <summary>
    /// To be player before the start method.
    /// </summary>
    private void Awake()
    {
        AudioListener.volume = 1f;
    }

    /// <summary>
    /// Play the game (starts at level 1).
    /// </summary>
    public void PlayGame()
    {
        scoreStats.Level1Score = default;
        scoreStats.Level2Score = default;
        levelLoader.LoadLevel(1);
    }

    /// <summary>
    /// Quit the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
        
}

