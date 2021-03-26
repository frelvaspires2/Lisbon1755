using System.Collections;
using UnityEngine;

/// <summary>
/// Manage the player's health.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    /// <summary>
    /// Access playerStats scriptableobject.
    /// </summary>
    [SerializeField]
    private PlayerStats playerStats;

    /// <summary>
    /// Player's health.
    /// </summary>
    [SerializeField] 
    private float health;

    /// <summary>
    /// Gets player health points.
    /// </summary>
    public float Health { get => health; }

    /// <summary>
    /// Checks whether the player is injured.
    /// </summary>
    public bool IsInjured { get; private set; }

    /// <summary>
    /// To be played on the first frame.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        health = playerStats.Health;
        IsInjured = false;
    }

    /// <summary>
    /// To be played every frame.
    /// </summary>
    private void Update()
    {
        CheckHealth();
    }

    /// <summary>
    /// Verify the state of the health.
    /// </summary>
    private void CheckHealth()
    {
        // If any health is lost, recover it.
        if(health < playerStats.Health)
        {
            // If player is below half in health, he becomes injured.
            if(health < playerStats.Health / 2)
            {
                IsInjured = true;
            }
            else
            {
                IsInjured = false;
            }
            StartCoroutine(HealingRoutine());
        }
        // Make sure the health doesn't go up more than it was set.
        else
        {
            health = playerStats.Health;
        }
    }

    /// <summary>
    /// Heal any health points that were lost.
    /// </summary>
    /// <returns> Recovers energy points every second.</returns>
    private IEnumerator HealingRoutine()
    {
        // Set how many seconds to recover health points.
        WaitForSeconds wfs = new WaitForSeconds(1);

        // Recover health points every second.
        if (health < playerStats.Health)
        {
            health += playerStats.HealthRegeneration;
            yield return wfs;
        }
        // Stop the coroutine.
        else
        {
            StopCoroutine(HealingRoutine());
        }
    }
}
