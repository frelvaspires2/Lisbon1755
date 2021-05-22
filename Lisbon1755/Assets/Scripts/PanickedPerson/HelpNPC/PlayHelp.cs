using UnityEngine;

/// <summary>
/// Help the agent when he's in the wounded state.
/// </summary>
public class PlayHelp : MonoBehaviour
{
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
    /// Checks whether the agent is wounded.
    /// </summary>
    [SerializeField]
    private bool isWounded;

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
        isWounded = false;
        clickCount = 0;
    }

    /// <summary>
    /// To be played in every frame of the game.
    /// </summary>
    private void Update()
    {
        CheckState();
        Help();
    }

    /// <summary>
    /// Checks if the opponent is in wounded state.
    /// </summary>
    private void CheckState()
    {
        if(panickedController.GetStates == PanickedState.WoundedInTheGround)
        {
            isWounded = true;
        }
        else
        {
            isWounded = false;
            isInside = false;
            clickCount = 0;
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
                }

                if(clickCount >= setClicks)
                {
                    panickedController.Health = panickedStats.Health / 1.5f;
                }
            }
        }
    }

    /// <summary>
    /// Checks whether the player is close to the agent.
    /// </summary>
    /// <param name="other"> Collider.</param>
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player && isWounded)
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
        if(other.gameObject == player && isWounded)
        {
            isInside = false;
        }
    }
}
