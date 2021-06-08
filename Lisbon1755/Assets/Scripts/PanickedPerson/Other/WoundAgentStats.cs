using UnityEngine;
using System;

/// <summary>
/// Setup the chosen agent/s to be given damage.
/// </summary>
[Serializable]
public struct WoundAgentStats 
{
    /// <summary>
    /// Acess chosen agent gameobject..
    /// </summary>
    [SerializeField]
    private GameObject selectedAgent;

    /// <summary>
    /// Gets the chosen agent gameobject.
    /// </summary>
    public GameObject SelectedAgent { get => selectedAgent; }

    /// <summary>
    /// Set whether the agent has taken damage.
    /// </summary>
    [SerializeField]
    private bool isDMG;

    /// <summary>
    /// Gets or sets whether the agent has taken damage.
    /// </summary>
    public bool IsDMG { get => isDMG; set => isDMG = value; }
}
