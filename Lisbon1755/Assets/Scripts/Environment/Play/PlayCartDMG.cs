using System.Collections;
using UnityEngine;

/// <summary>
/// Play the cart damage.
/// </summary>
public class PlayCartDMG : MonoBehaviour
{
    /// <summary>
    /// Access the cart marker UI.
    /// </summary>
    [SerializeField]
    private GameObject cartMarker;

    /// <summary>
    /// Access the cart collider.
    /// </summary>
    [SerializeField]
    private BoxCollider cartCollider;

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
    private PlayCart playCart;

    /// <summary>
    /// Check whether the player was hit.
    /// </summary>
    private bool isPlayerHit;

    /// <summary>
    /// Check if the animation is finished.
    /// </summary>
    [SerializeField]
    private bool isDone;

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
    /// Check if something entered on the trigger.
    /// </summary>
    /// <param name="other"> Collider</param>
    private void OnTriggerEnter(Collider other)
    {
        // If it's the player, then decrement health.
        if (other.gameObject == player && !isPlayerHit && !isDone)
        {
            player.GetComponent<PlayerHealth>().Health -= dmg;
            player.GetComponent<UI_GotHitScreen>().GotHit();
            isPlayerHit = true;
        }
        // If it's an NPC, then decrement health.
        if (other.gameObject.tag == "NPC" && !isNPCHit && !isDone)
        {
            other.GetComponent<PanickedController>().Health -= dmg;
            other.GetComponent<AISoundController>().GotHitSound();
            isNPCHit = true;
        }
    }

    /// <summary>
    /// To be played when the animation is finished.
    /// Update stuff.
    /// </summary>
    public void AnimationDone()
    {
        isDone = true;
        cartMarker.SetActive(false);
        cartCollider.isTrigger = false;
    }
}
