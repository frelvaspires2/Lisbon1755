using System.Collections;
using UnityEngine;

public class Heretics : MonoBehaviour
{
    [SerializeField]
    private EventsManager eventManager;

    [SerializeField]
    private GameObject stick;

    [SerializeField]
    private GameObject npcInDanger;

    [SerializeField]
    private GameObject npcSafe;

    [SerializeField]
    private GameObject npcDead;

    [SerializeField]
    private GameObject fire;

    [SerializeField]
    private float timeToDisappear = 5f;

    [SerializeField]
    private ScoreStats scoreStats;

    private bool hasWon;

    private void Start()
    {
        hasWon = false;
        fire.SetActive(false);
    }

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
                if (!hasWon)
                {
                    scoreStats.Level2Score += 1;
                    hasWon = true;
                }
                WonState();
                break;
            case EventResult.Lost:
                LostState();
                break;
        }
    }

    private void NoneState()
    {
        stick.SetActive(true);
        npcInDanger.SetActive(true);
        npcSafe.SetActive(false);
        npcDead.SetActive(false);
    }

    private void WonState()
    {
        stick.SetActive(true);
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
        stick.SetActive(true);
        npcInDanger.SetActive(false);
        npcSafe.SetActive(false);
        npcDead.SetActive(true);
        fire.SetActive(true);
    }

    private IEnumerator Disappear(GameObject gameObject)
    {
        WaitForSeconds wfs = new WaitForSeconds(timeToDisappear);

        yield return wfs;

        Destroy(gameObject);

        StopCoroutine(Disappear(gameObject));
    }
}
