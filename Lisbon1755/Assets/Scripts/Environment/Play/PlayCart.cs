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
    /// Check whether the mark is active.
    /// </summary>
    private bool isMarkerActive;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize stuff.
    /// </summary>
    private void Awake()
    {
        cartAnimator.enabled = false;
        cartMarker.SetActive(false);
        isMarkerActive = false;
    }

    /// <summary>
    /// Check if the player entered the area to play the cart.
    /// </summary>
    /// <param name="other"> Collider.</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            if (!isMarkerActive)
            {
                cartMarker.SetActive(true);
                isMarkerActive = true;
            }
            cartAnimator.enabled = true;
        }
    }
}
