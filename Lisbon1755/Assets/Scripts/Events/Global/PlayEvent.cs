using UnityEngine;

/// <summary>
/// Detect if the player is close to the NPC in the event.
/// </summary>
public class PlayEvent : MonoBehaviour
{
    /// <summary>
    /// Access player gameobject.
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// Check if the player is close.
    /// </summary>
    [SerializeField]
    private bool isClose;

    /// <summary>
    /// Gets the indication if the player is close.
    /// </summary>
    public bool IsClose { get => isClose; }

    /// <summary>
    /// To be played in the first frame.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        isClose = false;
    }

    /// <summary>
    /// Check if the player is close to the NPC.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            isClose = true;
        }
    }

    /// <summary>
    /// Checks if the player is no longer close to the NPC.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isClose = false;
        }
    }
}
