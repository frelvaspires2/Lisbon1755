using UnityEngine;
using System;

/// <summary>
/// The stats of each player sound source.
/// </summary>
[Serializable]
public struct SoundStats 
{
    /// <summary>
    /// The sound source.
    /// </summary>
    [SerializeField]
    private GameObject soundSource;

    /// <summary>
    /// Gets the sound source.
    /// </summary>
    public GameObject SoundSource { get => soundSource; }

    /// <summary>
    /// The sound type.
    /// </summary>
    [SerializeField]
    private SoundTypes soundTypes;

    /// <summary>
    /// Gets the sound type.
    /// </summary>
    public SoundTypes GetSoundTypes { get => soundTypes; }
}
