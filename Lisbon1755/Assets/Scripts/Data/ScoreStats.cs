using UnityEngine;

[CreateAssetMenu(menuName = "ScoreStats")]
public class ScoreStats : ScriptableObject
{
    [SerializeField]
    private int level1Score;

    [SerializeField]
    private int level2Score;

    public int Level1Score
    {
        get => level1Score;
        set => level1Score = value;
    }

    public int Level2Score
    {
        get => level2Score;
        set => level2Score = value;
    }

    public int FinalScore
    {
        get => level1Score + level2Score;
    }

    public void ResetLevel1Stats()
    {
        level1Score = default;
    }

    public void ResetLevel2Stats()
    {
        level2Score = default;
    }
}
