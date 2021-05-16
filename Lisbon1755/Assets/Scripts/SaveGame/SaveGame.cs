using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// Save the game.
/// </summary>
public class SaveGame : MonoBehaviour
{
    /// <summary>
    /// Access the GameStats scriptableobject.
    /// </summary>
    [SerializeField]
    private GameStats gameStats;

    /// <summary>
    /// Set the file path.
    /// </summary>
    private string path; //= Application.persistentDataPath + "/save.csv";

    /// <summary>
    /// To be played before the game begins.
    /// Set the file path.
    /// </summary>
    private void Awake()
    {
        path = "C:/Users/Francisco/Documents/GitHub/Lisbon1755/save.csv";
    }

    /// <summary>
    /// Save the game by creating/overwrite a save file.
    /// </summary>
    /// <param name="info"> The game stats to be saved.</param>
    public void SaveTheGame(Dictionary<int, SaveData> info)
    {
        using(StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine("Level, IsFinished?, PeopleSaved");

            for(int i = 0; i < info.Count; i++)
            {
                sw.WriteLine($"{info[i].Level}, {info[i].IsFinished}, {info[i].PeopleSaved}");
            }
        }
    }
}
