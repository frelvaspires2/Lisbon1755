using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SaveData 
{
    public int Level { get; }

    public bool IsFinished { get; }

    public int PeopleSaved { get; }

    public SaveData(int level, bool isFinished, int peopleSaved)
    {
        Level = level;
        IsFinished = isFinished;
        PeopleSaved = peopleSaved;
    }
}
