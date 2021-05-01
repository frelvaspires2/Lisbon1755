using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Control the energy bar.
/// </summary>
public class UI_EnergyBar : MonoBehaviour
{
    /// <summary>
    /// Access the slider UI.
    /// </summary>
    [SerializeField]
    public Slider energyBar;

    /// <summary>
    /// Access the GameData script.
    /// </summary>
    [SerializeField]
    private GameData gameData;


    /// <summary>
    /// To be played in every frame.
    /// Check whether any energy was spent.
    /// </summary>
    private void Update()
    {
        energyBar.value = gameData.Energy;
    }
}