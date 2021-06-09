using UnityEngine;

/// <summary>
/// Play the cart event.
/// </summary>
public class PlayCart : MonoBehaviour
{
    /// <summary>
    /// Access the UI marker of the cart.
    /// </summary>
    [SerializeField]
    private GameObject cartMarker;

    /// <summary>
    /// Access the cart animator.
    /// </summary>
    [SerializeField]
    private Animator cartAnimator;

    /// <summary>
    /// Access the player's gameobject.
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize stuff.
    /// </summary>
    private void Start()
    {
        cartAnimator.enabled = false;
        cartMarker.SetActive(false);
    }

    /// <summary>
    /// Check if the player entered the area to play the cart.
    /// </summary>
    /// <param name="other"> Collider.</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            cartMarker.SetActive(true);
            cartAnimator.enabled = true;
        }
    }
}
