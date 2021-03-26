using System.Collections;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
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
        if(energy < 0)
        {
            energy = 0;
        }

        if (energy < playerStats.Energy)
        {
            StartCoroutine(RecoveringRoutine());
        }
        else
        {
            energy = playerStats.Energy;
        }
    }

    /// <summary>
    /// Recover the energy.
    /// </summary>
    /// <returns> Time.</returns>
    private IEnumerator RecoveringRoutine()
    {
        WaitForSeconds wfs = new WaitForSeconds(1);

        if (energy < playerStats.Energy)
        {
            energy += 0.01f;
            yield return wfs;
        }
        StopCoroutine(RecoveringRoutine());
    }
}
