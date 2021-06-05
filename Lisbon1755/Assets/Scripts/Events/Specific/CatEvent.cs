using System.Collections;
using UnityEngine;

public class CatEvent : MonoBehaviour
{
    [SerializeField]
    private EventsManager eventManager;

    [SerializeField]
    private GameObject catInDanger;

    [SerializeField]
    private GameObject dyingCat;

    [SerializeField]
    private GameObject catSafe;

    [SerializeField]
    private GameObject catLadyScared;

    [SerializeField]
    private GameObject catLadyThankful;

    [SerializeField]
    private GameObject catLadySad;

    [SerializeField]
    private float timeToDisappear = 5f;

    [SerializeField]
    private ScoreStats scoreStats;

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
        catInDanger.SetActive(true);
        catSafe.SetActive(false);
        catLadyScared.SetActive(true);
        catLadyThankful.SetActive(false);
        catLadySad.SetActive(false);
        dyingCat.SetActive(false);
    }

    private void WonState()
    {
        catInDanger.SetActive(false);
        dyingCat.SetActive(false);
        if (catSafe != null)
        {
            catSafe.SetActive(true);
        }
        catLadyScared.SetActive(false);
        if (catSafe != null)
        {
            catLadyThankful.SetActive(true);
        }
        if (catLadySad != null)
        {
            catLadySad.SetActive(false);
        }

        StartCoroutine(Disappear(catSafe, catLadyThankful));
    }

    private void LostState()
    {
        catInDanger.SetActive(false);
        catSafe.SetActive(false);
        catLadyScared.SetActive(false);
        catLadyThankful.SetActive(false);
        catLadySad.SetActive(true);
        dyingCat.SetActive(true);
    }

    private IEnumerator Disappear(GameObject gameObject1, GameObject gameObject2)
    {
        WaitForSeconds wfs = new WaitForSeconds(timeToDisappear);

        yield return wfs;

        Destroy(gameObject1);
        Destroy(gameObject2);

        StopCoroutine(Disappear(gameObject1, gameObject2));
    }
}
