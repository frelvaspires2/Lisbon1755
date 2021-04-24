using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckInHouse : MonoBehaviour
{
    [SerializeField]
    private EventsManager eventManager;

    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private GameObject npcInDanger;

    [SerializeField]
    private GameObject npcSafe;

    [SerializeField]
    private float timeToDisappear = 5f;

    private void Update()
    {
        STM();
    }

    private void STM()
    {
        switch (eventManager.GetEventResult)
        {
            case EventResult.None:
                NoneState();
                break;
            case EventResult.Won:
                WonState();
                break;
            case EventResult.Lost:
                LostState();
                break;
        }
    }

    private void NoneState()
    {
        obstacle.SetActive(true);
        npcInDanger.SetActive(true);
        npcSafe.SetActive(false);
    }

    private void WonState()
    {
        obstacle.SetActive(false);
        npcInDanger.SetActive(false);
        npcSafe.SetActive(true);

        StartCoroutine(Disappear(npcSafe));
    }

    private void LostState()
    {
        obstacle.SetActive(true);
        npcInDanger.SetActive(false);
        npcSafe.SetActive(false);
    }

    private IEnumerator Disappear(GameObject gameObject)
    {
        WaitForSeconds wfs = new WaitForSeconds(timeToDisappear);

        yield return wfs;

        Destroy(gameObject);

        StopCoroutine(Disappear(gameObject));
    }
}
