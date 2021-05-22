using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Help the agent when he's in the wounded state.
/// </summary>
public class PlayHelp : MonoBehaviour
{
    /// <summary>
    /// Access the quick time event gameobject.
    /// </summary>
    [SerializeField]
    private GameObject qte;

    /// <summary>
    /// Access the quick time event image.
    /// </summary>
    [SerializeField]
    private Image qteImage;

    /// <summary>
    /// Access the player gameobject.
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// Access the PanickedController script.
    /// </summary>
    [SerializeField]
    private PanickedController panickedController;

    [SerializeField]
    private PlayerMovement playerMovement;

    /// <summary>
    /// Access the PanickedStats scriptableobject.
    /// </summary>
    [SerializeField]
    private PanickedStats panickedStats;

    /// <summary>
    /// Access the Transform of the helping position.
    /// </summary>
    [SerializeField]
    private Transform setPosition;

    /// <summary>
    /// Checks whether the player is inside the helping area.
    /// </summary>
    [SerializeField]
    private bool isInside;

    /// <summary>
    /// Set how many clicks are needed to help the agent.
    /// </summary>
    [SerializeField]
    private float setClicks;

    /// <summary>
    /// Count the number of clicks.
    /// </summary>
    [SerializeField]
    private float clickCount;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        isInside = false;
        clickCount = 0;
    }

    /// <summary>
    /// To be played in every frame of the game.
    /// </summary>
    private void Update()
    {
        if (CheckState())
        {
            Help();
        }
    }

    /// <summary>
    /// Check whether the opponent is in the wounded state.
    /// </summary>
    /// <returns> Returns true if the opponent is wounded.</returns>
    private bool CheckState()
    {
        if(panickedController.GetStates == PanickedState.WoundedInTheGround)
        {
            return true;
        }
        else
        {
            isInside = false;
            clickCount = 0;
            return false;
        }
    }

    /// <summary>
    /// Help the agent.
    /// </summary>
    private void Help()
    {
        if(isInside)
        {
            if(Input.GetButton("MouseClick"))
            {
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = setPosition.position;
                player.transform.rotation = setPosition.rotation;
                player.GetComponent<CharacterController>().enabled = true;

                if(clickCount < setClicks)
                {
                    clickCount += 1 * Time.deltaTime;
                    playerMovement.IsPlayHelp = true;
                    qte.SetActive(true);
                    qteImage.fillAmount = (clickCount / setClicks);
                }
                else if(clickCount >= setClicks)
                {
                    panickedController.Health = panickedStats.Health / 1.5f;
                    playerMovement.IsPlayHelp = false;
                    qte.SetActive(false);
                }
                else
                {
                    qte.SetActive(false);
                }
            }
            else
            {
                playerMovement.IsPlayHelp = false;
                qte.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Checks whether the player is close to the agent.
    /// </summary>
    /// <param name="other"> Collider.</param>
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player && CheckState())
        {
            isInside = true;
        }
    }

    /// <summary>
    /// Checks whether the player is close to the agent.
    /// </summary>
    /// <param name="other"> Collider.</param>
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player && CheckState())
        {
            isInside = false;
        }
    }
}
