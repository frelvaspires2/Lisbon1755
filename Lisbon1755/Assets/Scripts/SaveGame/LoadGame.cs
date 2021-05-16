using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;

public class LoadGame : MonoBehaviour
{
    [SerializeField]
    private GameStats gameStats;

    private string path; //= Application.persistentDataPath + "/save.csv";

    // Start is called before the first frame update
    private void Start()
    {
        path = "C:/Users/Francisco/Documents/GitHub/Lisbon1755/save.csv";
        ReadFile();
    }

    private void ReadFile()
    {
        string content = "";
        string[] lines;
        int[] index = new int[3];
        int count = 0;

        string levelNumber = "";
        string checkIfFinished = "";
        string peopleSavedNumber = "";

        for (int i = 0; i < index.Length; i++)
        {
            index[i] = 0;
        }

        using (StreamReader sr = File.OpenText(path))
        {
            /*while ((content = sr.ReadLine()) != null)
            {
                lines = (content.Split(','));
                Debug.Log(content);
            }*/

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
                count++;

                lines = (content.Split(','));
                //Debug.Log(content);

                levelNumber = lines[index[0]];
                checkIfFinished = lines[index[1]];
                peopleSavedNumber = lines[index[2]];

                gameStats.DataDic.Add(count, new SaveData(
                    Convert.ToInt32(levelNumber),
                    Convert.ToBoolean(checkIfFinished),
                    Convert.ToInt32(peopleSavedNumber)));
            }
        }

        // Testing...
        foreach(KeyValuePair<int, SaveData> item in gameStats.DataDic)
        {
            Debug.Log($"Key: {item.Key}.  " +
                $"Level: {item.Value.Level}.  " +
                $"IsFinished: {item.Value.IsFinished}.  " +
                $"PeopleSaved: {item.Value.PeopleSaved}");
        }
    }
}
