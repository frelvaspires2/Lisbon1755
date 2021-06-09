using UnityEngine;
using System.Collections;

/// <summary>
/// Stuck in objects event specific stuff.
/// </summary>
public class StuckInObjects : MonoBehaviour
{
    /// <summary>
    /// Access the EventsManager script.
    /// </summary>
    [SerializeField]
    private EventsManager eventManager;

    /// <summary>
    /// Access the obstacle gameobject.
    /// </summary>
    [SerializeField]
    private GameObject obstacle;

    /// <summary>
    /// Access the finished gameobject.
    /// </summary>
    [SerializeField]
    private GameObject finished;

    /// <summary>
    /// Access the npc in danger gameobject.
    /// </summary>
    [SerializeField]
    private GameObject npcInDanger;

    /// <summary>
    /// Access the dead npc gameobject.
    /// </summary>
    [SerializeField]
    private GameObject npcDead;

    /// <summary>
    /// Access the npc in safety gameobject.
    /// </summary>
    [SerializeField]
    private GameObject npcSafe;

    /// <summary>
    /// Access the animated rock gameobject.
    /// </summary>
    [SerializeField]
    private GameObject animatedRock;

    /// <summary>
    /// Set the time for the NPC to disappear.
    /// </summary>
    [SerializeField]
    private float timeToDisappear = 5f;

    /// <summary>
    /// Access the score state scriptableobject.
    /// </summary>
    [SerializeField]
    private ScoreStats scoreStats;

    /// <summary>
    /// Access the rock animator.
    /// </summary>
    [SerializeField]
    private Animator animator;

    /// <summary>
    /// Set the name of the animation to be played.
    /// </summary>
    [SerializeField]
    private string animationName;

    /// <summary>
    /// Set the name of the idle animation to be played.
    /// </summary>
    [SerializeField]
    private string idleName;

    /// <summary>
    /// Set the time of the rock animation.
    /// </summary>
    [SerializeField]
    private float rockAnimTime;

    /// <summary>
    /// Checks whether the player has won.
    /// </summary>
    private bool hasWon;

    /// <summary>
    /// Checks whether the animation is done.
    /// </summary>
    private bool isAnimDone;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize stuff.
    /// </summary>
    private void Start()
    {
        hasWon = false;
        animatedRock.SetActive(false);
        isAnimDone = false;
    }

    /// <summary>
    /// To be played in every frame.
    /// Run the state machine.
    /// </summary>
    private void Update()
    {
        STM();
    }

    /// <summary>
    /// The state machine.
    /// </summary>
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

    /// <summary>
    /// The state when nothing has happened yet.
    /// </summary>
    private void NoneState()
    {
        obstacle.SetActive(true);
        finished.SetActive(false);
        npcInDanger.SetActive(true);
        npcSafe.SetActive(false);
        npcDead.SetActive(false);

        if(eventManager.isClick)
        {
            animator.Play(animationName);
        }
        else
        {
            animator.Play(idleName);
        }
    }

    /// <summary>
    /// The state when the player won.
    /// </summary>
    private void WonState()
    {
        obstacle.SetActive(false);
        npcDead.SetActive(false);

        if(!isAnimDone)
        {
            StartCoroutine(RockAnimation());
            isAnimDone = true;
        }

        StartCoroutine(Disappear(npcSafe));
    }

    /// <summary>
    /// The state when the player lost.
    /// </summary>
    private void LostState()
    {
        obstacle.SetActive(true);
        finished.SetActive(false);
        npcInDanger.SetActive(false);
        npcSafe.SetActive(false);
        npcDead.SetActive(true);
    }

    /// <summary>
    /// Disappear the NPC.
    /// </summary>
    /// <param name="gameObject"> The stuck npc.</param>
    /// <returns> Wait for seconds.</returns>
    private IEnumerator Disappear(GameObject gameObject)
    {
        WaitForSeconds wfs = new WaitForSeconds(timeToDisappear);

        yield return wfs;

        Destroy(gameObject);

        StopCoroutine(Disappear(gameObject));
    }
    
    /// <summary>
    /// Play the rock animation.
    /// </summary>
    /// <returns> Wait for seconds.</returns>
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
