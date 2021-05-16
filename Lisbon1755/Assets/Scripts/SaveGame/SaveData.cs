
/// <summary>
/// Save game stats.
/// </summary>
public struct SaveData
{
    /// <summary>
    /// Level number.
    /// </summary>
    public int Level { get; }

    /// <summary>
    /// Gets whether the level is finished.
    /// </summary>
    public bool IsFinished { get; }

    /// <summary>
    /// Number of people saved.
    /// </summary>
    public int PeopleSaved { get; }

    /// <summary>
    /// Initialize the properties.
    /// </summary>
    /// <param name="level"> Level number. </param>
    /// <param name="isFinished"> Checks whether the level is finished. </param>
    /// <param name="peopleSaved"> Number of people saved. </param>
    public SaveData(int level, bool isFinished, int peopleSaved)
    {
        Level = level;
        IsFinished = isFinished;
        PeopleSaved = peopleSaved;
    }
}
