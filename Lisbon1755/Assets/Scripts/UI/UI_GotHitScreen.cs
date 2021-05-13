using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
    /// Access the sound.
    /// </summary>
    [SerializeField]
    private GameObject sound;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        sound.SetActive(false);
    }

    /// <summary>
    /// Make the screen red while the player is injured.
    /// </summary>
    private void GotHurt()
    {
        var color = gotHitScreen.color;

        color.a = 0.5f;

        gotHitScreen.color = color;
    }

    /// <summary>
    /// Make the screen red for a bit when the player is hit.
    /// </summary>
    public void GotHit()
    {
        Color color = gotHitScreen.color;

        color.a = 0.5f;

        gotHitScreen.color = color;

        sound.SetActive(true);

        StartCoroutine(HitRoutine());
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
                Color color = gotHitScreen.color;
                color.a -= 0.01f;
                gotHitScreen.color = color;
            }
        }
    }

    /// <summary>
    /// Make the screen return to normal after the player being hit.
    /// </summary>
    /// <returns> Wait for seconds.</returns>
    private IEnumerator HitRoutine()
    {
        WaitForSeconds wfs = new WaitForSeconds(0.5f);

        yield return wfs;

        sound.SetActive(false);

        Color color = gotHitScreen.color;

        color.a = 0.0f;

        gotHitScreen.color = color;
    }
}