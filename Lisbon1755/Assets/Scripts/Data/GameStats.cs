using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keep game stats dictionary.
/// </summary>
[CreateAssetMenu(menuName = "GameStats")]
public class GameStats : ScriptableObject
{
    /// <summary>
    /// Final game stats.
    /// </summary>
    private List<SaveData> gameStatsDic = new List<SaveData>();

    /// <summary>
    /// Gets final game stats.
    /// </summary>
    public List<SaveData> GameStatsDic
    {
        get => gameStatsDic;
        set => gameStatsDic = value;
    }
}
