using System;
using UnityEngine;

/// <summary>
/// Set up the animations.
/// </summary>
[Serializable]
public struct SetAnimations 
{
    /// <summary>
    /// Animation type.
    /// </summary>
    [SerializeField]
    private PlayerAnimTypes animationType;

    /// <summary>
    /// Gets the animation type.
    /// </summary>
    public PlayerAnimTypes AnimationType { get => animationType; }

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
