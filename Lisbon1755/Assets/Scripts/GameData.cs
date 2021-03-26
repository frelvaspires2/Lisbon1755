using UnityEngine;

/// <summary>
/// Game data (to be accessed by UIs etc).
/// </summary>
public class GameData : MonoBehaviour
{
    /// <summary>
    /// Access PlayerHealth script.
    /// </summary>
    [SerializeField]
    private PlayerHealth playerHealth;

    /// <summary>
    /// Access PlayerEnergy script.
    /// </summary>
    [SerializeField]
    private PlayerEnergy playerEnergy;

    /// <summary>
    /// Player's health.
    /// </summary>
    [SerializeField]
    private float health;

    /// <summary>
    /// Gets player's health.
    /// </summary>
    public float Health { get => health; }

    /// <summary>
    /// Check if the player is injured.
    /// </summary>
    [SerializeField]
    private bool isInjured;

    /// <summary>
    /// Gets whether the player is injured.
    /// </summary>
    public bool IsInjured { get => isInjured; }

    /// <summary>
    /// Player's energy points.
    /// </summary>
    [SerializeField]
    private float energy;

    /// <summary>
    /// Gets player energy.
    /// </summary>
    public float Energy { get => energy; }

    /// <summary>
    /// To be played every frame.
    /// Update the variables.
    /// </summary>
    private void Update()
    {
        health = playerHealth.Health;
        isInjured = playerHealth.IsInjured;
        energy = playerEnergy.Energy;
    }
}
