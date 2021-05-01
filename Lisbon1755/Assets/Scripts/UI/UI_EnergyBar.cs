using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Control the energy bar.
/// </summary>
public class UI_EnergyBar : MonoBehaviour
{
    /// <summary>
    /// Access the energy bar.
    /// </summary>
    [SerializeField]
    public Slider energyBar;

    /// <summary>
    /// Set the max energy value.
    /// </summary>
    [SerializeField]
    private float maxEnergy;

    /// <summary>
    /// Check what is the current energy value.
    /// </summary>
    [SerializeField]
    private float currentEnergy;

    /// <summary>
    /// Access the slider.
    /// </summary>
    [SerializeField]
    private Slider slider;

    /// <summary>
    /// Access the GameData script.
    /// </summary>
    [SerializeField]
    private GameData gameData;

    /// <summary>
    /// Access the PlayerStats scriptable object.
    /// </summary>
    [SerializeField]
    private PlayerStats playerStats;

    /// <summary>
    /// To be played in the first frame.
    /// Setup variables.
    /// </summary>
    private void Start()
    {
        maxEnergy = playerStats.Energy;

        currentEnergy = maxEnergy;

        energyBar.maxValue = maxEnergy;

        energyBar.value = maxEnergy;
    }

    /// <summary>
    /// Refill the slider.
    /// </summary>
    private void SliderEnergy()
    {
        currentEnergy = gameData.Energy;

        energyBar.value = currentEnergy;
    }

    /// <summary>
    /// To be played in every frame.
    /// Check whether any energy was spent.
    /// </summary>
    private void Update()
    {
        if(gameData.Energy < playerStats.Energy)
        {
            SliderEnergy();
        }
    }
}