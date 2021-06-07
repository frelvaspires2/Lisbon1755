using System.Collections;
using UnityEngine;

/// <summary>
/// Script to end animation for wake up event.
/// </summary>
public class EndAnim : MonoBehaviour
{
    /// <summary>
    /// Access the CameraShake script.
    /// </summary>
    [SerializeField]
    private CameraShake cameraShake;

    /// <summary>
    /// Check whether the animation has finished.
    /// </summary>
    [SerializeField]
    private bool isAnimationFinished;

    /// <summary>
    /// Gets whether the animation has finished.
    /// </summary>
    public bool IsAnimationFinished { get => isAnimationFinished; }

    /// <summary>
    /// Access the damage zone script.
    /// </summary>
    [SerializeField]
    private GameObject dmgZone;

    /// <summary>
    /// Access the block zone script.
    /// </summary>
    [SerializeField]
    private GameObject blockZone;

    [SerializeField]
    private GameObject sound;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Setup variables.
    /// </summary>
    private void Start()
    {
        isAnimationFinished = false;
        dmgZone.SetActive(false);
        blockZone.SetActive(false);
    }

    /// <summary>
    /// Stop the animation.
    /// To be called in the animation frame as event.
    /// </summary>
    public void StopAnim()
    {
        isAnimationFinished = true;
        dmgZone.SetActive(true);
        //Destroy(sound);
        sound.SetActive(false);
        StartCoroutine(StopDMG());
    }

    /// <summary>
    /// Stop the damage.
    /// </summary>
    /// <returns> Wait for seconds.</returns>
    private IEnumerator StopDMG()
    {
        WaitForSeconds wfs = new WaitForSeconds(1);

        yield return wfs;

        Destroy(dmgZone);

        blockZone.SetActive(true);
    }
}
