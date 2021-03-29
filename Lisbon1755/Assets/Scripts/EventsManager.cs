using System.Collections;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;


    [SerializeField]
    private PlayEvent playEvent;

    [SerializeField]
    private int eventCounter;

    public int EventCounter { get => eventCounter; }

    [SerializeField]
    private int setEventTime = 10;

    [SerializeField]
    private int setHowManyClicks = 5;

    [SerializeField]
    private int clickCount;

    public int ClickCount { get => clickCount; }

    [SerializeField]
    private EventResult eventResult;

    [SerializeField]
    private EventState eventState;

    private void Start()
    {
        eventState = EventState.Inactive;
        eventResult = EventResult.None;
    }

    private void Update()
    {
        EventSTM();
    }

    // state machine do evento
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

    // começar evento (começar timer etc)
    private void StartEvent()
    {
        eventState = EventState.Active;
        StartCoroutine(Timer());
    }

    // jogar o evento (clicar várias vezes)
    private void PlayEvent()
    {
        if(playEvent.IsClose)
        {
            if(Input.GetButtonUp("MouseClick"))
            {
                if (clickCount < setHowManyClicks)
                {
                    clickCount++;
                }
                else
                {
                    clickCount = setHowManyClicks;
                }
            }
        }
    }

    // começar evento
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && eventState == EventState.Inactive)
        {
            // começar evento
            StartEvent();
        }
    }

    // timer do evento
    private IEnumerator Timer()
    {
        WaitForSeconds wfs = new WaitForSeconds(1);
        eventCounter = setEventTime;

        while (eventCounter > 0)
        {
            yield return wfs;
            eventCounter--;
        }
        eventState = EventState.Finished;
        StopCoroutine(Timer());
    }
}
