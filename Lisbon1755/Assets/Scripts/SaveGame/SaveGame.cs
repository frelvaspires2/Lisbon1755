﻿using System.Collections.Generic;
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
    private string path; 

    private string level2Path;

    /// <summary>
    /// To be played before the game begins.
    /// Set the file path.
    /// </summary>
    private void Awake()
    {
        path = Application.persistentDataPath + "/save.csv";
        level2Path = Application.persistentDataPath + "/level2.txt";

        Debug.Log("Path: " + Application.persistentDataPath);
    }

    /// <summary>
    /// Save the game by creating/overwrite a save file.
    /// </summary>
    /// <param name="info"> The game stats to be saved.</param>
    public void SaveTheGame(List<SaveData> info)
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

    /// <summary>
    /// Unlock the level 2.
    /// </summary>
    public void UnlockLevel2()
    {
        using (StreamWriter sw = File.CreateText(level2Path))
        {
            sw.WriteLine("Unlocked");
        }
    }
}
