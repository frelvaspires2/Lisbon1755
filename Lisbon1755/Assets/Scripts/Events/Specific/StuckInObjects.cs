using UnityEngine;
using System.Collections;

public class StuckInObjects : MonoBehaviour
{
    [SerializeField]
    private EventsManager eventManager;

    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private GameObject finished;

    [SerializeField]
    private GameObject npcInDanger;

    [SerializeField]
    private GameObject npcDead;

    [SerializeField]
    private GameObject npcSafe;

    [SerializeField]
    private float timeToDisappear = 5f;

    [SerializeField]
    private EventsResultStats eventsResultStats;

    private void Update()
    {
        STM();
    }

    private void STM()
    {
        switch(eventManager.GetEventResult)
        {
            case EventResult.None:
                eventsResultStats.EventsResult[0] = EventResult.None;
                NoneState();
                break;
            case EventResult.Won:
                eventsResultStats.EventsResult[0] = EventResult.Won;
                WonState();
                break;
            case EventResult.Lost:
                eventsResultStats.EventsResult[0] = EventResult.Lost;
                LostState();
                break;
        }
    }

    private void NoneState()
    {
        obstacle.SetActive(true);
        finished.SetActive(false);
        npcInDanger.SetActive(true);
        npcSafe.SetActive(false);
        npcDead.SetActive(false);
    }

    private void WonState()
    {
        obstacle.SetActive(false);
        finished.SetActive(true);
        npcInDanger.SetActive(false);
        if (npcSafe != null)
        {
            npcSafe.SetActive(true);
        }
        npcDead.SetActive(false);

        StartCoroutine(Disappear(npcSafe));
    }

    private void LostState()
    {
        obstacle.SetActive(true);
        finished.SetActive(false);
        npcInDanger.SetActive(false);
        npcSafe.SetActive(false);
        npcDead.SetActive(true);
    }

    private IEnumerator Disappear(GameObject gameObject)
    {
        WaitForSeconds wfs = new WaitForSeconds(timeToDisappear);

        yield return wfs;

        Destroy(gameObject);

        StopCoroutine(Disappear(gameObject));
    }
}
