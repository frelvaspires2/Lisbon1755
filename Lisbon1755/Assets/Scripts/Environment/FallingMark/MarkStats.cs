using UnityEngine;
using System;

/// <summary>
/// Stats of the mark.
/// </summary>
[Serializable]
public struct MarkStats 
{
    /// <summary>
    /// Access the mark.
    /// </summary>
    [SerializeField]
    private GameObject mark;

    /// <summary>
    /// Gets the mark.
    /// </summary>
    public GameObject Mark { get => mark; }

    /// <summary>
    /// Sets the time to start showing the mark.
    /// </summary>
    [SerializeField]
    private float timeToStart;

    /// <summary>
    /// Gets the time to start showing the mark.
    /// </summary>
    public float TimeToStart { get => timeToStart; }

    /// <summary>
    /// Sets the time to stop showing the mark.
    /// </summary>
    [SerializeField]
    private float timeToEnd;

    /// <summary>
    /// Gets the time to stop showing the mark.
    /// </summary>
    public float TimeToEnd { get => timeToEnd; }
}
