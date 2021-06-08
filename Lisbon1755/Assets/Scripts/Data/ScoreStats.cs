using UnityEngine;

/// <summary>
/// Score stats of each level.
/// </summary>
[CreateAssetMenu(menuName = "ScoreStats")]
public class ScoreStats : ScriptableObject
{
    /// <summary>
    /// Score points of level 1.
    /// </summary>
    [SerializeField]
    private int level1Score;

    /// <summary>
    /// Score points of level 2.
    /// </summary>
    [SerializeField]
    private int level2Score;

    /// <summary>
    /// Gets or sets the score points of level 1.
    /// </summary>
    public int Level1Score
    {
        get => level1Score;
        set => level1Score = value;
    }

    /// <summary>
    /// Gets or sets the score points of level 2.
    /// </summary>
    public int Level2Score
    {
        get => level2Score;
        set => level2Score = value;
    }

    /// <summary>
    /// Gets the sum level 1 and level 2 scores.
    /// </summary>
    public int FinalScore
    {
        get => level1Score + level2Score;
    }

    /// <summary>
    /// Reset the level 1 score.
    /// </summary>
    public void ResetLevel1Stats()
    {
        level1Score = default;
    }

    /// <summary>
    /// Reset the level 2 score.
    /// </summary>
    public void ResetLevel2Stats()
    {
        level2Score = default;
    }
}
