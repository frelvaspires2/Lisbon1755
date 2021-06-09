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
    /// Access the score stats scriptableobject.
    /// </summary>
    [SerializeField]
    private ScoreStats scoreStats;

    /// <summary>
    /// Set the save file path.
    /// </summary>
    private string path; 

    /// <summary>
    /// Set the level 2 file path.
    /// </summary>
    private string level2Path; 

    /// <summary>
    /// To be played before the game stats.
    /// Set the file path.
    /// </summary>
    private void Awake()
    {
        path = Application.persistentDataPath + "/save.csv";
        level2Path = Application.persistentDataPath + "/level2.txt";

        Debug.Log("Path: " + Application.persistentDataPath);
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

                // Add the data to the game stats scriptableobject.
                gameStats.GameStatsDic.Add(new SaveData(
                    Convert.ToInt32(levelNumber),
                    Convert.ToBoolean(checkIfFinished),
                    Convert.ToInt32(peopleSavedNumber)));
            }

            // Add the data to the score stats scriptableobject.
            scoreStats.Level1Score = gameStats.GameStatsDic[0].PeopleSaved;
            scoreStats.Level2Score = gameStats.GameStatsDic[1].PeopleSaved;
        }
    }


    /// <summary>
    /// Check if level 2 was unlocked.
    /// </summary>
    public bool CheckIfLevel2IsUnlocked()
    {
        if (File.Exists(level2Path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
