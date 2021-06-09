using System.Collections;
using UnityEngine;

/// <summary>
/// Play damage in falling buildings animation.
/// </summary>
public class PlayDMGAnim : MonoBehaviour
{
    /// <summary>
    /// Access the player gameobject.
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// Set the damage points.
    /// </summary>
    [SerializeField]
    private float dmg;

    /// <summary>
    /// Access the PlayAnim script.
    /// </summary>
    [SerializeField]
    private PlayAnim playAnim;

    /// <summary>
    /// Check whether the player was hit.
    /// </summary>
    private bool isPlayerHit;

    /// <summary>
    /// Check whether the NPC was hit.
    /// </summary>
    private bool isNPCHit;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        isPlayerHit = false;
        isNPCHit = false;
    }

    /// <summary>
    /// To be played in every frame.
    /// </summary>
    private void Update()
    {
        // Check if the animation finished playing.
        if(playAnim.IsDone)
        {
            StartCoroutine(Destroy());
        }
    }

    /// <summary>
    /// Check if something entered on the trigger.
    /// </summary>
    /// <param name="other"> Collider</param>
    private void OnTriggerStay(Collider other)
    {
        // If it's the player, then decrement health.
        if (other.gameObject == player && playAnim.IsDone && !isPlayerHit)
        {
            player.GetComponent<PlayerHealth>().Health -= dmg;
            player.GetComponent<UI_GotHitScreen>().GotHit();
            isPlayerHit = true;
        }
        // If it's an NPC, then decrement health.
        if (other.gameObject.tag == "NPC" && playAnim.IsDone && !isNPCHit)
        {
            other.GetComponent<PanickedController>().Health -= dmg;
            other.GetComponent<AISoundController>().GotHitSound();
            isNPCHit = true;
        }
    }

    /// <summary>
    /// Time for the destruction of the script.
    /// </summary>
    /// <returns> Wait for seconds.</returns>
    private IEnumerator Destroy()
    {
        WaitForSeconds wfs = new WaitForSeconds(1);

        yield return wfs;

        Destroy(gameObject);
    }
}
