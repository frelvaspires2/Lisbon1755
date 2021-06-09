using UnityEngine;

/// <summary>
/// Unlock the UI markers.
/// </summary>
public class UnlockMarker : MonoBehaviour
{
    /// <summary>
    /// Access the markers gameobject.
    /// </summary>
    [SerializeField]
    private GameObject[] marker;

    /// <summary>
    /// Access the player's gameobject.
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// Checks whether the mark was activated.
    /// </summary>
    private bool isActivated;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Set all the marks to false.
    /// Set isActivated to false.
    /// </summary>
    private void Start()
    {
        foreach (GameObject item in marker)
        {
            item.SetActive(false);
        }

        isActivated = false;
    }

    /// <summary>
    /// Detect if the player entered the trigger.
    /// </summary>
    /// <param name="other"> Detected collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player && !isActivated)
        {
            foreach(GameObject item in marker)
            {
                item.SetActive(true);
            }

            isActivated = true;
        }
    }
}
