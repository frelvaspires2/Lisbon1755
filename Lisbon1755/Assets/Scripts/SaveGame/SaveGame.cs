using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveGame : MonoBehaviour
{
    [SerializeField]
    private GameStats gameStats;

    private string path; //= Application.persistentDataPath + "/save.csv";

    private void Awake()
    {
        path = "C:/Users/Francisco/Documents/GitHub/Lisbon1755/save.csv";
        CreateFile();
    }

    private void CreateFile()
    {
        using(StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine("Level, IsFinished?, PeopleSaved");
            sw.WriteLine("1, true, 3");
            sw.WriteLine("2, false, 0");
        }
    }
}
