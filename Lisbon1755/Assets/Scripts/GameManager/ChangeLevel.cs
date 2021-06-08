using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Change the current level.
/// </summary>
public class ChangeLevel : MonoBehaviour
{
    /// <summary>
    /// The scene index.
    /// </summary>
    private int scene;

    /// <summary>
    /// Access the LevelLoader script.
    /// </summary>
    [SerializeField]
    private LevelLoader leverLoader;

    /// <summary>
    /// Access the GameStats script.
    /// </summary>
    [SerializeField]
    private GameStats gameStats;

    /// <summary>
    /// Access the SaveGame script.
    /// </summary>
    [SerializeField]
    private SaveGame saveGame;

    /// <summary>
    /// Access the score stats scriptableobject.
    /// </summary>
    [SerializeField]
    private ScoreStats scoreStats;

    /// <summary>
    /// Access the player's gameobject.
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// Checks whether the player arrived at the end of the level.
    /// </summary>
    [SerializeField]
    private bool isEnd;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Get the index of the current scene.
    /// </summary>
    private void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }

    /// <summary>
    /// Save the game.
    /// </summary>
    private void SaveGame()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            gameStats.GameStatsDic.Add(new SaveData(1, true, 
                scoreStats.Level1Score));
            saveGame.UnlockLevel2();
        }
        else if(SceneManager.GetActiveScene().name == "Level2")
        {
            gameStats.GameStatsDic.Add(new SaveData(2, true, 
                scoreStats.Level2Score));
        }

        saveGame.SaveTheGame(gameStats.GameStatsDic);
    }

    /// <summary>
    /// Detect if the player entered the end of the level.
    /// </summary>
    /// <param name="other"> Collider.</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            if (!isEnd)
            {
                SaveGame();
                leverLoader.LoadLevel(scene + 1);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
