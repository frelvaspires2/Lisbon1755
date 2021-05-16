using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keep game stats dictionary.
/// </summary>
[CreateAssetMenu(menuName = "GameStats")]
public class GameStats : ScriptableObject
{
    /// <summary>
    /// Game stats.
    /// </summary>
    private Dictionary<int, SaveData> gameStatsDic = new Dictionary<int, SaveData>();

    /// <summary>
    /// Gets game stats.
    /// </summary>
    public Dictionary<int, SaveData> GameStatsDic
    {
        get => gameStatsDic;
        set => gameStatsDic = value;
    }
}
