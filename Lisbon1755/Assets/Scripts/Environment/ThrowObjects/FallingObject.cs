using UnityEngine;

/// <summary>
/// Falling object script.
/// </summary>
public class FallingObject : MonoBehaviour
{
    /// <summary>
    /// Set how much damage will give.
    /// </summary>
    [SerializeField]
    private float dmg;

    /// <summary>
    /// Access itself.
    /// </summary>
    [SerializeField]
    private GameObject fallingObject;

    /// <summary>
    /// Check if collided with something.
    /// </summary>
    /// <param name="other"> Collision detection.</param>
    private void OnTriggerEnter(Collider other)
    {
        // In case it's the player.
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().Health -= dmg;
            Destroy(fallingObject);
        }
        // In case it's an NPC.
        if(other.gameObject.tag == "NPC")
        {
            other.GetComponent<PanickedController>().Health -= dmg;
            Destroy(fallingObject);
        }
        // In case it's the floor of the game.
        if(other.gameObject.tag == "Floor")
        {
            Destroy(fallingObject);
        }
    }
}
