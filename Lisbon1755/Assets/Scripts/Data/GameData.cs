using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Game data (to be accessed by UIs etc).
/// </summary>
public class GameData : MonoBehaviour
{
    /// <summary>
    /// Access PlayerHealth script.
    /// </summary>
    [SerializeField]
    private PlayerHealth playerHealth;

    /// <summary>
    /// Access PlayerEnergy script.
    /// </summary>
    [SerializeField]
    private PlayerEnergy playerEnergy;

    /// <summary>
    /// Player's health.
    /// </summary>
    [SerializeField]
    private float health;

    /// <summary>
    /// Gets player's health.
    /// </summary>
    public float Health { get => health; }

    /// <summary>
    /// Check if the player is injured.
    /// </summary>
    [SerializeField]
    private bool isInjured;

    /// <summary>
    /// Gets whether the player is injured.
    /// </summary>
    public bool IsInjured { get => isInjured; }

    /// <summary>
    /// Player's energy points.
    /// </summary>
    [SerializeField]
    private float energy;

    /// <summary>
    /// Gets player energy.
    /// </summary>
    public float Energy { get => energy; }

    /// <summary>
    /// Access the current scene.
    /// </summary>
    private Scene scene;

    /// <summary>
    /// Access the EventsManager script.
    /// </summary>
    [SerializeField]
    private EventsManager eventsManager;

    /// <summary>
    /// Checks whether the player is clicking in the event.
    /// </summary>
    [SerializeField]
    private bool isPlayerClickingEvent;

    /// <summary>
    /// Access the PlayerMovement script.
    /// </summary>
    [SerializeField]
    private PlayerMovement playerMovement;

    /// <summary>
    /// Check how many clicks the player has done in the event.
    /// </summary>
    [SerializeField]
    private int howManyClicks;

    /// <summary>
    /// Gets how many clicks the player has done in the event.
    /// </summary>
    public int HowManyClicks { get => howManyClicks; }

    /// <summary>
    /// Check the event countdown.
    /// </summary>
    [SerializeField]
    private float clickCount;

    /// <summary>
    /// Gets the event countdown.
    /// </summary>
    public float ClickCount { get => clickCount; }

    /// <summary>
    /// Gets whether the player is clicking in the event.
    /// </summary>
    public bool IsPlayerClickingEvent { get => isPlayerClickingEvent; }

    /// <summary>
    /// Check the event time counter.
    /// </summary>
    [SerializeField]
    private int eventTimeCounter;

    /// <summary>
    /// Gets the event time counter.
    /// </summary>
    public int EventTimeCounter { get => eventTimeCounter; }

    /// <summary>
    /// Check the initial event time.
    /// </summary>
    [SerializeField]
    private int setEventTime;

    /// <summary>
    /// Get the initial event time.
    /// </summary>
    public int SetEventTime { get => setEventTime; }

    [SerializeField]
    private EventsResultStats eventsResultsStats;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        eventsManager = null;
        ResetValues();
    }

    /// <summary>
    /// To be played every frame.
    /// Update the variables.
    /// Check if the player is dead.
    /// </summary>
    private void Update()
    {
        UpdateVariables();
        CheckIfDead();
    }

    /// <summary>
    /// Check if the player died, if so, reload the current scene.
    /// </summary>
    private void CheckIfDead()
    {
        if (health <= 0)
        {
            eventsResultsStats.ResetStats();
            SceneManager.LoadScene(scene.name);
        }

        // cheat core to restart the game
        if(Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(scene.name);
        }
    }

    /// <summary>
    /// Update the variables.
    /// </summary>
    private void UpdateVariables()
    {
        health = playerHealth.Health;
        isInjured = playerHealth.IsInjured;
        energy = playerEnergy.Energy;

        CheckIfTheresEvent();
    }

    /// <summary>
    /// Check if the player is inside of an event.
    /// </summary>
    private void CheckIfTheresEvent()
    {
        if(playerMovement.eventsManager != null)
        {
            eventsManager = playerMovement.eventsManager;
            AccessEventValues();
        }
        else
        {
            ResetValues();
        }
    }

    /// <summary>
    /// Access the event values.
    /// </summary>
    private void AccessEventValues()
    {
        isPlayerClickingEvent = eventsManager.isClick;
        howManyClicks = eventsManager.HowManyClicks;
        clickCount = eventsManager.ClickCount;
        eventTimeCounter = eventsManager.EventTimeCounter;
        setEventTime = eventsManager.SetEventTime;
    }

    /// <summary>
    /// Reset the event values.
    /// </summary>
    private void ResetValues()
    {
        isPlayerClickingEvent = default;
        howManyClicks = default;
        clickCount = default;
        eventTimeCounter = default;
        setEventTime = default;
    }
}
