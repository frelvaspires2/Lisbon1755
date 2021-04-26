using UnityEngine;
using UnityEngine.SceneManagement;

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
    /// Access the current scene.
    /// </summary>
    private Scene scene;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    /// <summary>
    /// To be played every frame.
    /// Update the variables.
    /// Check if the player is dead.
    /// </summary>
    private void Update()
    {
        UpdateVariables();
        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(scene.name);
        }
    }

    private void UpdateVariables()
    {
        health = playerHealth.Health;
        isInjured = playerHealth.IsInjured;
        energy = playerEnergy.Energy;
    }
}
