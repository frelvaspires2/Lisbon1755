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
    /// To be played on the first frame.
    /// </summary>
    private void Start()
    {
        health = playerStats.Health;
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
    /// <returns></returns>
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
