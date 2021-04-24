using UnityEngine;

/// <summary>
/// Play the animation when the player enters the area.
/// </summary>
public class PlayAnim : MonoBehaviour
{
    // Player's gameobject.
    [SerializeField]
    private GameObject player;

    // Animation controller.
    [SerializeField]
    private Animator animController;

    // Insert animation name.
    [SerializeField]
    private string animName;

    // Check if the animation was already played.
    [SerializeField]
    private bool isPlayed;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        isPlayed = false;
        animController = GetComponent<Animator>();
    }

    /// <summary>
    /// Detect trigger when enters.
    /// </summary>
    /// <param name="other"> The object collider.</param>
    private void OnTriggerEnter(Collider other)
    {
        // If triggers player and the animation hasn't already played.
        if(other.gameObject == player && !isPlayed)
        {
            // Can't play next time.
            isPlayed = true;
            // Play the animation.
            animController.Play(animName);
        }
    }
}
