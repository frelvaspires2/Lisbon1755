﻿using UnityEngine;

/// <summary>
/// Give dmg to the player or NPC when they are hit by an object.
/// </summary>
public class PlayDMG : MonoBehaviour
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
    /// Check if something entered on the trigger.
    /// </summary>
    /// <param name="other"> Collider</param>
    private void OnTriggerEnter(Collider other)
    {
        // If it's the player, then decrement health.
        if(other.gameObject == player)
        {
            player.GetComponent<PlayerHealth>().Health -= dmg;
        }
        // If it's an NPC, then decrement health.
        if(other.gameObject.tag == "NPC")
        {
            //Remove agent life when their code is completed.
            //Debug.Log("Teste - Hit agent");
        }
    }
}
