using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Help the agent when he's in the wounded state.
/// </summary>
public class PlayHelp : MonoBehaviour
{
    /// <summary>
    /// Access the score stats scriptableobject.
    /// </summary>
    [SerializeField]
    private ScoreStats scoreStats;

    /// <summary>
    /// Access the help UI gameobject.
    /// </summary>
    [SerializeField]
    private GameObject helpUI;

    /// <summary>
    /// Access the signal gameobject.
    /// </summary>
    [SerializeField]
    private GameObject signal;

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

    /// <summary>
    /// Access the PlayerMovement script.
    /// </summary>
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
    /// Checks whether the score was added.
    /// </summary>
    private bool isScoreAdded;

    /// <summary>
    /// Checks whether the level 1 was finished.
    /// </summary>
    private bool isLevel1;

    /// <summary>
    /// Access the current scene.
    /// </summary>
    private Scene currentScene;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        isInside = false;
        clickCount = 0;
        signal.SetActive(false);
        isScoreAdded = false;

        currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == "Level1")
        {
            isLevel1 = true;
        }
        else if(currentScene.name == "Level2")
        {
            isLevel1 = false;
        }
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
    /// Check whether the agent is in the wounded state.
    /// </summary>
    /// <returns> Returns true if the agent is wounded.</returns>
    private bool CheckState()
    {
        if(panickedController.GetStates == PanickedState.WoundedInTheGround)
        {
            signal.SetActive(true);
            return true;
        }
        else
        {
            signal.SetActive(false);
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
            helpUI.SetActive(true);

            if(Input.GetButton("MouseClick"))
            {
                helpUI.SetActive(false);

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

                    if(!isScoreAdded)
                    {
                        if(isLevel1)
                        {
                            scoreStats.Level1Score += 1;
                        }
                        else if(!isLevel1)
                        {
                            scoreStats.Level2Score += 1;
                        }

                        isScoreAdded = true;
                    }
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
        else
        {
            helpUI.SetActive(false);
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
    /// Checks whether the player left the agent.
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
