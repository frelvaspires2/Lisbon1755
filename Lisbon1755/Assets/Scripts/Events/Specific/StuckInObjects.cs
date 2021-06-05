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
    private GameObject animatedRock;

    [SerializeField]
    private float timeToDisappear = 5f;

    [SerializeField]
    private ScoreStats scoreStats;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private string animationName;

    [SerializeField]
    private string idleName;

    [SerializeField]
    private float rockAnimTime;

    private bool hasWon;

    private bool isAnimDone;

    private void Start()
    {
        hasWon = false;
        animatedRock.SetActive(false);
        isAnimDone = false;
    }

    private void Update()
    {
        STM();
    }

    private void STM()
    {
        switch(eventManager.GetEventResult)
        {
            case EventResult.None:
                NoneState();
                break;
            case EventResult.Won:
                if (!hasWon)
                {
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
        finished.SetActive(false);
        npcInDanger.SetActive(true);
        npcSafe.SetActive(false);
        npcDead.SetActive(false);

        if(eventManager.isClick)
        {
            //Debug.Log("Correr animação");
            animator.Play(animationName);
        }
        else
        {
            animator.Play(idleName);
        }
    }

    private void WonState()
    {
        obstacle.SetActive(false);
        //finished.SetActive(true);
        //npcInDanger.SetActive(false);
        /*if (npcSafe != null)
        {
            npcSafe.SetActive(true);
        }*/
        npcDead.SetActive(false);

        if(!isAnimDone)
        {
            StartCoroutine(RockAnimation());
            isAnimDone = true;
        }

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
    
    private IEnumerator RockAnimation()
    {
        WaitForSeconds wfs1 = new WaitForSeconds(0);

        WaitForSeconds wfs2 = new WaitForSeconds(rockAnimTime);

        yield return wfs1;

        animatedRock.SetActive(true);

        yield return wfs2;

        animatedRock.SetActive(false);

        finished.SetActive(true);

        npcInDanger.SetActive(false);

        if (npcSafe != null)
        {
            npcSafe.SetActive(true);
        }

        StopCoroutine(RockAnimation());
    }
}
