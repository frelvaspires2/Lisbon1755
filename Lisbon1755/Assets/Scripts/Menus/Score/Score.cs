using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Show the score.
/// </summary>
public class Score : MonoBehaviour
{
    /// <summary>
    /// Access the score stats scriptableobject.
    /// </summary>
    [SerializeField]
    private ScoreStats scoreStats;

    /// <summary>
    /// Count the number of people saved.
    /// </summary>
    [SerializeField]
    private int winCount;

    /// <summary>
    /// Access the text of the result.
    /// </summary>
    [SerializeField]
    private Text saved;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Calculate and set the results.
    /// </summary>
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Calculate();
        SetResult();
    }

    /// <summary>
    /// Calculate the results.
    /// </summary>
    private void Calculate()
    {
        winCount = scoreStats.FinalScore;
    }

    /// <summary>
    /// Set the results in the screen.
    /// </summary>
    private void SetResult()
    {
        saved.text = winCount.ToString();
    }
}
