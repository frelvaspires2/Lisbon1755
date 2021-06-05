using System.Collections;
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
    private Animator doorAnimator;

    [SerializeField]
    private GameObject fire;

    [SerializeField]
    private float timeToDisappear = 5f;

    [SerializeField]
    private ScoreStats scoreStats;

    [SerializeField]
    private string doorAnimName;

    private bool hasWon;

    private void Start()
    {
        hasWon = false;
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
                if (!hasWon) {
                    scoreStats.Level1Score += 1;
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
        obstacle.SetActive(true);
        npcInDanger.SetActive(true);
        npcSafe.SetActive(false);
        fire.SetActive(false);
    }

    private void WonState()
    {
        //obstacle.SetActive(false);
        npcInDanger.SetActive(false);
        fire.SetActive(false);
        if (npcSafe != null)
        {
            npcSafe.SetActive(true);
        }

        doorAnimator.Play(doorAnimName);

        StartCoroutine(Disappear(npcSafe));
    }

    private void LostState()
    {
        obstacle.SetActive(true);
        npcInDanger.SetActive(false);
        npcSafe.SetActive(false);
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
