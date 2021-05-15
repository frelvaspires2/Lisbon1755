using UnityEngine;
using System;

/// <summary>
/// Sound stats for each AI sound.
/// </summary>
[Serializable]
public struct AISoundStats 
{
    /// <summary>
    /// Access the sound gameobject.
    /// </summary>
    [SerializeField]
    private GameObject sound;

    /// <summary>
    /// Gets the sound gameobject.
    /// </summary>
    public GameObject Sound { get => sound; }

    /// <summary>
    /// Access the sound types.
    /// </summary>
    [SerializeField]
    private AISoundTypes aiSoundTypes;

    /// <summary>
    /// Gets the sound types.
    /// </summary>
    public AISoundTypes GetAISoundType { get => aiSoundTypes; }
}
