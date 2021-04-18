using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    // Player's gameobject.
    [SerializeField]
    private GameObject player;

    // Animation controller.
    [SerializeField]
    private Animator animController;

    // Check if the animation was already played.
    private bool isPlayed;

    /// <summary>s
    /// To be played in the first frame of the game.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        isPlayed = false;
    }

    /// <summary>
    /// Detect trigger when enters.
    /// </summary>
    /// <param name="other"> The object collider.</param>
    private void OnTriggerEnter(Collider other)
    {
        // If triggers player and the animation hasn't already played.
        if(other == player && !isPlayed)
        {
            // Can't play next time.
            isPlayed = true;
            // Play the animation (insert the animation name).
            animController.Play("New State");
        }
    }
}
