using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

/// <summary>
/// Load the game.
/// </summary>
public class LoadGame : MonoBehaviour
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
    /// To be played before the game stats.
    /// Set the file path.
    /// </summary>
    private void Awake()
    {
        path = "C:/Users/Francisco/Documents/GitHub/Lisbon1755/save.csv";
    }

    /// <summary>
    /// Read the file.
    /// </summary>
    public void LoadTheGame()
    {
        string content = "";
        string[] lines;
        int[] index = new int[3];

        string levelNumber = "";
        string checkIfFinished = "";
        string peopleSavedNumber = "";

        for (int i = 0; i < index.Length; i++)
        {
            index[i] = 0;
        }

        using (StreamReader sr = File.OpenText(path))
        {
            // Divide the first line and put each type in the array.
            content = sr.ReadLine();
            lines = new string[content.Length];
            lines = content.Split(',');

            // Identify the index of each cell.
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("Level"))
                {
                    index[0] = i;
                }

                if (lines[i].Contains("IsFinished?"))
                {
                    index[1] = i;
                }

                if (lines[i].Contains("PeopleSaved"))
                {
                    index[2] = i;
                }
            }

            // Verify the values of cells
            while ((content = sr.ReadLine()) != null)
            {
                lines = (content.Split(','));

                levelNumber = lines[index[0]];
                checkIfFinished = lines[index[1]];
                peopleSavedNumber = lines[index[2]];

                // Add the data to the scriptableobject.
                gameStats.GameStatsDic.Add(new SaveData(
                    Convert.ToInt32(levelNumber),
                    Convert.ToBoolean(checkIfFinished),
                    Convert.ToInt32(peopleSavedNumber)));
            }
        }
    }
}
