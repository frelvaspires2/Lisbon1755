using UnityEngine;
using System;

/// <summary>
/// The stats of each spawner.
/// </summary>
[Serializable]
public struct SpawnerStats 
{
    /// <summary>
    /// Set speed to the spawn.
    /// </summary>
    [SerializeField]
    private float speed;

    /// <summary>
    /// Gets the speed of the spawn.
    /// </summary>
    public float Speed { get => speed; }

    /// <summary>
    /// Set direction to the spawn.
    /// </summary>
    [SerializeField]
    private float directionY;

    /// <summary>
    /// Gets the direction of the spawn.
    /// </summary>
    public float DirectionY { get => directionY; }

    /// <summary>
    /// Check whether the game designer wants to add force to the spawn.
    /// </summary>
    [SerializeField]
    private bool addForce;

    /// <summary>
    /// Gets whether the game designer wants to add force to the spawn.
    /// </summary>
    public bool AddForce { get => addForce; }

    /// <summary>
    /// Set the position of the spawner.
    /// </summary>
    [SerializeField]
    private Transform position;

    /// <summary>
    /// Get the position of the spawner.
    /// </summary>
    public Transform Position { get => position; }
}
