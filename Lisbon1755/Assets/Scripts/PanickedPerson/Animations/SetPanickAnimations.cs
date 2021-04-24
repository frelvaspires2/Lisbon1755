using System;
using UnityEngine;

/// <summary>
/// Set up the animations.
/// </summary>
[Serializable]
public struct SetPanicAnimations
{
    /// <summary>
    /// Animation type.
    /// </summary>
    [SerializeField]
    private PanickAnimTypes animationType;

    /// <summary>
    /// Gets the animation type.
    /// </summary>
    public PanickAnimTypes AnimationType { get => animationType; }

    /// <summary>
    /// The animated gameobject.
    /// </summary>
    [SerializeField]
    private GameObject animation;

    /// <summary>
    /// Gets the animated gameobject.
    /// </summary>
    public GameObject Animation { get => animation; }
}
