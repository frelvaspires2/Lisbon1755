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
    private PlayerHealth player;

    /// <summary>
    /// Player's health.
    /// </summary>
    [SerializeField]
    private float playerHealth;

    /// <summary>
    /// Gets player's health.
    /// </summary>
    public float PlayerHealth { get => PlayerHealth; }

    /// <summary>
    /// To be played every frame.
    /// </summary>
    private void Update()
    {
        playerHealth = player.Health;
    }
}
