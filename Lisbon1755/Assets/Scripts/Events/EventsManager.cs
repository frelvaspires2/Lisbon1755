using System.Collections;
using UnityEngine;

/// <summary>
/// Manage the event.
/// </summary>
public class EventsManager : MonoBehaviour
{
    /// <summary>
    /// Access the player's gameobject.
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// Access the PlayEvent enum.
    /// </summary>
    [SerializeField]
    private PlayEvent playEvent;

    /// <summary>
    /// Countdown the event time.
    /// </summary>
    [SerializeField]
    private int eventTimeCounter;

    /// <summary>
    /// Gets the countdown of the event.
    /// </summary>
    public int EventTimeCounter { get => eventTimeCounter; }

    /// <summary>
    /// Set the event maximum time to complete.
    /// </summary>
    [SerializeField]
    private int setEventTime = 10;

    /// <summary>
    /// Set how many times the player must click to complete it.
    /// </summary>
    [SerializeField]
    private int setHowManyClicks = 5;

    /// <summary>
    /// Gets the number of times the player must click to complete it.
    /// </summary>
    public int HowManyClicks { get => setHowManyClicks; }

    /// <summary>
    /// Count how many times the player clicked.
    /// </summary>
    [SerializeField]
    private float clickCount;

    /// <summary>
    /// Gets the number of clicks the player has clicked.
    /// </summary>
    public float ClickCount { get => clickCount; }

    /// <summary>
    /// Access the EventResult enum.
    /// </summary>
    [SerializeField]
    private EventResult eventResult;

    /// <summary>
    /// Gets the EventResult enum.
    /// </summary>
    public EventResult GetEventResult { get => eventResult; }

    /// <summary>
    /// Access the EventState enum.
    /// </summary>
    [SerializeField]
    private EventState eventState;

    /// <summary>
    /// Gets the EventState enum.
    /// </summary>
    public EventState GetEventState { get => eventState; }

    /// <summary>
    /// Access the EventAnim enum.
    /// </summary>
    [SerializeField]
    private EventType eventType;

    /// <summary>
    /// Gets the EventAnim enum.
    /// </summary>
    public EventType GetEventType { get => eventType; }

    /// <summary>
    /// Access the PlayerMovement script.
    /// </summary>
    [SerializeField]
    private PlayerMovement playerMovement;

    

    /// <summary>
    /// To be played on the first frame.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        eventState = EventState.Inactive;
        eventResult = EventResult.None;
    }

    /// <summary>
    /// To be played in every frame.
    /// </summary>
    private void Update()
    {
        EventSTM();
    }

    /// <summary>
    /// Event's state machine.
    /// </summary>
    private void EventSTM()
    {
        switch(eventState)
        {
            case EventState.Inactive:
                eventResult = EventResult.None;
                break;
            case EventState.Active:
                PlayEvent();
                break;
            case EventState.Finished:
                if(clickCount == setHowManyClicks)
                {
                    eventResult = EventResult.Won;
                }
                else
                {
                    eventResult = EventResult.Lost;
                }
                break;
        }
    }

    /// <summary>
    /// Start the event.
    /// </summary>
    private void StartEvent()
    {
        eventState = EventState.Active;
        StartCoroutine(Timer());
    }

    /// <summary>
    /// Play the event.
    /// </summary>
    private void PlayEvent()
    {
        if(playEvent.IsClose)
        {
            if(Input.GetButton("MouseClick"))
            {
                CheckAnimationType();

                if (clickCount < setHowManyClicks)
                {
                    clickCount += 1 * Time.deltaTime;
                }
                else
                {
                    eventResult = EventResult.Won;
                    eventState = EventState.Finished;
                    clickCount = setHowManyClicks;
                }
            }
            else
            {
                playerMovement.GetPlayerAnimTypes = PlayerAnimTypes.idle;
            }
        }
    }

    private void CheckAnimationType()
    {
        switch(eventType)
        {
            case EventType.PersonStuckObjects:
                playerMovement.GetPlayerAnimTypes = PlayerAnimTypes.Push;
                break;
            case EventType.PersonStuckHouse:
                playerMovement.GetPlayerAnimTypes = PlayerAnimTypes.KickDoor;
                break;
            case EventType.Heretics:
                playerMovement.GetPlayerAnimTypes = PlayerAnimTypes.Untie;
                break;
            case EventType.Cat:
                playerMovement.GetPlayerAnimTypes = PlayerAnimTypes.CallCat;
                break;
            case EventType.WakeUp:
                playerMovement.GetPlayerAnimTypes = PlayerAnimTypes.WakeUpNPC;
                break;
        }
    }

    /// <summary>
    /// Start the event.
    /// </summary>
    /// <param name="other"> Chosen collider.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && eventState == EventState.Inactive)
        {
            // começar evento
            StartEvent();
        }
    }

    /// <summary>
    /// Event's timer.
    /// </summary>
    /// <returns> Returns time.</returns>
    private IEnumerator Timer()
    {
        WaitForSeconds wfs = new WaitForSeconds(1);
        eventTimeCounter = setEventTime;

        while (eventTimeCounter > 0)
        {
            yield return wfs;
            eventTimeCounter--;
        }
        eventState = EventState.Finished;
        StopCoroutine(Timer());
    }
}
