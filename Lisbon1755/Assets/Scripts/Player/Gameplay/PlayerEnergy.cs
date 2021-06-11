using System.Collections;
using UnityEngine;

/// <summary>
/// Manage the player's energy.
/// </summary>
public class PlayerEnergy : MonoBehaviour
{
    /// <summary>
    /// Access the PauseMenu script.
    /// </summary>
    [SerializeField]
    private PauseMenu pauseMenu;

    /// <summary>
    /// Access PlayerStats scriptableobject.
    /// </summary>
    [SerializeField]
    private PlayerStats playerStats;

    /// <summary>
    /// Player's energy points.
    /// </summary>
    [SerializeField]
    private float energy;

    /// <summary>
    /// Gets player energy.
    /// </summary>
    public float Energy { get => energy; set => energy = value; }

    /// <summary>
    /// To be played on the first frame of the game.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        energy = playerStats.Energy;
    }

    /// <summary>
    /// To be played every frame.
    /// </summary>
    private void Update()
    {
        CheckEnergy();
    }

    /// <summary>
    /// Check the energy.
    /// </summary>
    private void CheckEnergy()
    {
        // Make sure the energy doesn't go below 0.
        if(energy < 0)
        {
            energy = 0;
        }

        // If eny energy is lost, recover it.
        if (energy < playerStats.Energy && !pauseMenu.GameIsPaused)
        {
            StartCoroutine(RecoveringRoutine());
        }
        else if(energy < playerStats.Energy && pauseMenu.GameIsPaused)
        {
            energy = energy;
        }
        // Make sure the energy doesn't go up more than it was set.
        else
        {
            energy = playerStats.Energy;
        }
    }

    /// <summary>
    /// Recover the energy.
    /// </summary>
    /// <returns> Recovers energy points every second.</returns>
    private IEnumerator RecoveringRoutine()
    {
        // Set how many seconds to recover energy points.
        WaitForSeconds wfs = new WaitForSeconds(1);

        // Recover energy points every second.
        if (energy < playerStats.Energy)
        {
            energy += playerStats.EnergyRegeneration;
            yield return wfs;
        }
        // Stop the coroutine.
        else
        {
            StopCoroutine(RecoveringRoutine());
        }
    }
}
