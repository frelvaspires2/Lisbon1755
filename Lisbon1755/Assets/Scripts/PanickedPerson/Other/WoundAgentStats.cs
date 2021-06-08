using UnityEngine;
using System;

[Serializable]
public struct WoundAgentStats 
{
    [SerializeField]
    private GameObject selectedAgent;

    public GameObject SelectedAgent { get => selectedAgent; }

    [SerializeField]
    private bool isDMG;

    public bool IsDMG { get => isDMG; set => isDMG = value; }
}
