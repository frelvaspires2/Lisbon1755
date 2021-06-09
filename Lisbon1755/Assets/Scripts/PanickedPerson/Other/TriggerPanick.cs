using UnityEngine;

/// <summary>
/// Spawn the agents.
/// </summary>
public class TriggerPanick : MonoBehaviour
{
    /// <summary>
    /// Access the player gameobject.
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// Access the spawn gameobject (the agent's group).
    /// </summary>
    [SerializeField]
    private GameObject spawn;

    /// <summary>
    /// Checks whether the agents were spawned.
    /// </summary>
    private bool isSpawn;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize stuff.
    /// </summary>
    private void Start()
    {
        isSpawn = false;
        spawn.SetActive(false);
    }

    /// <summary>
    /// Detect if the player entered the trigger.
    /// </summary>
    /// <param name="other"> Detected collider.</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            if(!isSpawn)
            {
                spawn.SetActive(true);
                isSpawn = true;
            }
        }
    }
}
