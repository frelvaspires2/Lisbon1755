using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manage the got hit ui.
/// </summary>
public class UI_GotHitScreen : MonoBehaviour
{
    /// <summary>
    /// Access the got hit image.
    /// </summary>
    [SerializeField]
    private Image gotHitScreen;

    /// <summary>
    /// Access the GameData script.
    /// </summary>
    [SerializeField]
    private GameData gameData;

    /// <summary>
    /// Make the screen red.
    /// </summary>
    private void GotHurt()
    {
        var color = gotHitScreen.color;

        color.a = 0.8f;

        gotHitScreen.color = color;
    }

    /// <summary>
    /// To be played in every frame.
    /// Checks whether the player was hit.
    /// </summary>
    private void Update()
    {
        if (gameData.IsInjured == true)
        {
            GotHurt();
        }

        if (gotHitScreen != null)
        {
            if (gotHitScreen.color.a > 0)
            {
                var color = gotHitScreen.color;
                color.a -= 0.01f;
                gotHitScreen.color = color;
            }
        }
    }
}