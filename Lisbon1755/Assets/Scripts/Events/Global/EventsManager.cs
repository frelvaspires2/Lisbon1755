using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manage the event.
/// </summary>
public class EventsManager : MonoBehaviour
{
    /// <summary>
    /// Access the won UI.
    /// </summary>
    [SerializeField]
    private GameObject wonUI;

    /// <summary>
    /// Access the lost UI.
    /// </summary>
    [SerializeField]
    private GameObject lostUI;

    /// <summary>
    /// Access the default ground material.
    /// </summary>
    [SerializeField]
    private Material defaultColor;

    /// <summary>
    /// Access the won ground material.
    /// </summary>
    [SerializeField]
    private Material wonColor;

    /// <summary>
    /// Access the lost ground material.
    /// </summary>
    [SerializeField]
    private Material lostColor;

    /// <summary>
    /// Access the event area ground material.
    /// </summary>
    [SerializeField]
    private Material eventArea;

    /// <summary>
    /// Access the player's gameobject.
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// Access the transform of the interaction point.
    /// </summary>
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
    /// Get the event maximum time to complete.
    /// </summary>
    public int SetEventTime { get => setEventTime; }

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

    /// <summary>
    /// Access the event marker UI.
    /// </summary>
    [SerializeField]
    private GameObject eventMarker;

    /// <summary>
    /// Gets whether the player is clicking in event.
    /// </summary>
    public bool isClick { get; private set; }

    /// <summary>
    /// Access the timer gameobject.
    /// </summary>
    [SerializeField]
    private GameObject timer;

    /// <summary>
    /// Access the time slider.
    /// </summary>
    [SerializeField]
    private Slider timerSlider;

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
    /// Checks whether the time must be stopped.
    /// </summary>
    [SerializeField]
    private bool stopTimer;

    /// <summary>
    /// Access the idle sound of the event.
    /// </summary>
    [SerializeField]
    private GameObject idleSound;

    /// <summary>
    /// Access the sound in case of loss in the event.
    /// </summary>
    [SerializeField]
    private GameObject lossSound;

    /// <summary>
    /// Access the sound in case of win in the event.
    /// </summary>
    [SerializeField]
    private GameObject winSound;

    /// <summary>
    /// Access the ask for click UI.
    /// </summary>
    [SerializeField]
    private GameObject clickUI;

    
    /// <summary>
    /// To be played on the first frame.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        isClick = false;
        eventState = EventState.Inactive;
        eventResult = EventResult.None;
        timer.SetActive(false);
        qte.SetActive(false);
        stopTimer = false;
        clickUI.SetActive(false);
        wonUI.SetActive(false);
        lostUI.SetActive(false);
        eventArea.color = defaultColor.color;
    }

    /// <summary>
    /// To be played in every frame.
    /// </summary>
    private void Update()
    {
        EventSTM();
        TimerUI();
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
                eventArea.color = defaultColor.color;
                IdleSound();
                break;
            case EventState.Active:
                eventArea.color = defaultColor.color;
                PlayEvent();
                break;
            case EventState.Finished:
                if(clickCount == setHowManyClicks)
                {
                    eventResult = EventResult.Won;
                    eventArea.color = wonColor.color;
                    WinSound();
                }
                else
                {
                    eventResult = EventResult.Lost;
                    eventArea.color = lostColor.color;
                    LossSound();
                }
                clickUI.SetActive(false);
                eventMarker.SetActive(false);
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
            clickUI.SetActive(true);

            if(Input.GetButton("MouseClick"))
            {
                qte.SetActive(true);
                isClick = true;
                CheckAnimationType();

                player.transform.position = interact.position;
                player.transform.rotation = interact.rotation;

                if (clickCount < setHowManyClicks)
                {
                    clickCount += 1 * Time.deltaTime;
                    qteImage.fillAmount = (clickCount / setHowManyClicks);
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
                qte.SetActive(false);
                isClick = false;
                playerAnimController.GetSetPlayerAnimTypes = 
                    PlayerAnimTypes.idle;
            }
        }
        else
        {
            clickUI.SetActive(false);
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
                playerAnimController.GetSetPlayerAnimTypes = 
                    PlayerAnimTypes.Push;
                break;
            case EventType.PersonStuckHouse:
                playerAnimController.GetSetPlayerAnimTypes = 
                    PlayerAnimTypes.KickDoor;
                break;
            case EventType.Heretics:
                playerAnimController.GetSetPlayerAnimTypes = 
                    PlayerAnimTypes.Untie;
                break;
            case EventType.Cat:
                playerAnimController.GetSetPlayerAnimTypes = 
                    PlayerAnimTypes.CallCat;
                break;
            case EventType.WakeUp:
                playerAnimController.GetSetPlayerAnimTypes = 
                    PlayerAnimTypes.WakeUpNPC;
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
            eventMarker.SetActive(false);
        }
    }

    /// <summary>
    /// While staying inside the event.
    /// </summary>
    /// <param name="other"> Collider.</param>
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player && eventState != EventState.Finished)
        {
            timer.SetActive(true);
            timerSlider.maxValue = setEventTime;
            timerSlider.GetComponent<Slider>().value = eventTimeCounter;
        }

        if(other.gameObject == player && eventState == EventState.Finished)
        {
            timer.SetActive(false);
            qte.SetActive(false);
        }

        if(other.gameObject == player && eventResult == EventResult.Won)
        {
            wonUI.SetActive(true);
            lostUI.SetActive(false);
        }

        if (other.gameObject == player && eventResult == EventResult.Lost)
        {
            wonUI.SetActive(false);
            lostUI.SetActive(true);
        }
    }

    /// <summary>
    /// Update the timer UI.
    /// </summary>
    private void TimerUI()
    {
        if (eventTimeCounter <= 0)
        {
            stopTimer = true;
        }
       if(!stopTimer)
        {
            timerSlider.value = eventTimeCounter;
        }
    }

    /// <summary>
    /// Play the idle sound.
    /// </summary>
    private void IdleSound()
    {
        idleSound.SetActive(true);
        lossSound.SetActive(false);
        winSound.SetActive(false);
    }

    /// <summary>
    /// Play the loss sound.
    /// </summary>
    private void LossSound()
    {
        if (lossSound != null)
        {
            idleSound.SetActive(false);
            lossSound.SetActive(true);
            winSound.SetActive(false);
        }
    }

    /// <summary>
    /// Play the win sound.
    /// </summary>
    private void WinSound()
    {
        if (winSound != null)
        {
            idleSound.SetActive(false);
            lossSound.SetActive(false);
            winSound.SetActive(true);
        }
    }

    /// <summary>
    /// Exit the event.
    /// </summary>
    /// <param name="other"> Chosen collider.</param>
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            other.GetComponent<PlayerMovement>().eventsManager = null;
            timer.SetActive(false);
        }
        if (other.gameObject == player && eventState != EventState.Finished)
        {
            eventMarker.SetActive(true);
        }

        wonUI.SetActive(false);
        lostUI.SetActive(false);
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
