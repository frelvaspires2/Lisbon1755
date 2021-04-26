using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField]
    private PlayAnim playAnim;

    private void Update()
    {
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
        if (other.gameObject == player && playAnim.IsDone)
        {
            player.GetComponent<PlayerHealth>().Health -= dmg;
        }
        // If it's an NPC, then decrement health.
        if (other.gameObject.tag == "NPC" && playAnim.IsDone)
        {
            other.GetComponent<PanickedController>().Health -= dmg;
        }
    }

    private IEnumerator Destroy()
    {
        WaitForSeconds wfs = new WaitForSeconds(1);

        yield return wfs;

        Destroy(this);
    }
}
