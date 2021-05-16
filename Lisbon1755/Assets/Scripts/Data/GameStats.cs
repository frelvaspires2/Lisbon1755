using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameStats")]
public class GameStats : ScriptableObject
{
    private Dictionary<int, SaveData> dataDic = new Dictionary<int, SaveData>();

    public Dictionary<int, SaveData> DataDic
    {
        get => dataDic;
        set => dataDic = value;
    }
}
