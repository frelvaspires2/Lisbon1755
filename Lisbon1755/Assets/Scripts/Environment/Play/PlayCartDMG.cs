using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCartDMG : MonoBehaviour
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
        if (isDone)
        {
            StartCoroutine(Destroy());
        }
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
            isNPCHit = true;
        }
    }

    public void AnimationDone()
    {
        isDone = true;
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
