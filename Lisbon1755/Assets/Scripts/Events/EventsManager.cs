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


    [SerializeField]
    private Transform interact;

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
    private PlayerAnimController playerAnimController;

    public bool isClick { get; private set; }
    

    /// <summary>
    /// To be played on the first frame.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        isClick = false;
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
                isClick = true;
                CheckAnimationType();

                player.transform.position = interact.position;
                player.transform.rotation = interact.rotation;

                if (clickCount < setHowManyClicks)
                {
                    clickCount += 1 * Time.deltaTime;
                }
                else
                {
                    isClick = false;
                    eventResult = EventResult.Won;
                    eventState = EventState.Finished;
                    clickCount = setHowManyClicks;
                }
            }
            else
            {
                isClick = false;
                playerAnimController.GetSetPlayerAnimTypes = PlayerAnimTypes.idle;
            }
        }
    }

    /// <summary>
    /// Verify which animation the player will make.
    /// </summary>
    private void CheckAnimationType()
    {
        switch(eventType)
        {
            case EventType.PersonStuckObjects:
                playerAnimController.GetSetPlayerAnimTypes = PlayerAnimTypes.Push;
                break;
            case EventType.PersonStuckHouse:
                playerAnimController.GetSetPlayerAnimTypes = PlayerAnimTypes.KickDoor;
                break;
            case EventType.Heretics:
                playerAnimController.GetSetPlayerAnimTypes = PlayerAnimTypes.Untie;
                break;
            case EventType.Cat:
                playerAnimController.GetSetPlayerAnimTypes = PlayerAnimTypes.CallCat;
                break;
            case EventType.WakeUp:
                playerAnimController.GetSetPlayerAnimTypes = PlayerAnimTypes.WakeUpNPC;
                break;
        }
    }

    /// <summary>
    /// Start the event.
    /// </summary>
    /// <param name="other"> Chosen collider.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && eventState != EventState.Finished)
        {
            // começar evento
            StartEvent();
            other.GetComponent<PlayerMovement>().eventsManager = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            other.GetComponent<PlayerMovement>().eventsManager = null;
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
