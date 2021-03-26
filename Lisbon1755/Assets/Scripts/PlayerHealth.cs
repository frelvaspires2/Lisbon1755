using System.Collections;
using UnityEngine;

/// <summary>
/// Player health management.
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    /// <summary>
    /// Access playerStats scriptableObject.
    /// </summary>
    [SerializeField]
    private PlayerStats playerStats;

    /// <summary>
    /// Health points.
    /// </summary>
    [SerializeField] 
    private float health;

    /// <summary>
    /// Gets health points.
    /// </summary>
    public float Health { get => health; }

    /// <summary>
    /// Checks whether the player is injured.
    /// </summary>
    public bool IsInjured { get; private set; }

    /// <summary>
    /// To be played on the first frame.
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
        if(health < playerStats.Health)
        {
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
        else
        {
            health = playerStats.Health;
        }
    }

    /// <summary>
    /// Heal any health points that were lost.
    /// </summary>
    /// <returns> Time.</returns>
    private IEnumerator HealingRoutine()
    {
        WaitForSeconds wfs = new WaitForSeconds(1);

        if(health < playerStats.Health)
        {
            health += 0.001f;
            yield return wfs;
        }
        StopCoroutine(HealingRoutine());
    }
}
