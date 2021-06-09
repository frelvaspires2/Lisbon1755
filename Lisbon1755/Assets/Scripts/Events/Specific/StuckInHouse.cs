using System.Collections;
using UnityEngine;

/// <summary>
/// Stuck in house event specific stuff.
/// </summary>
public class StuckInHouse : MonoBehaviour
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
    /// Access the npc in danger gameobject.
    /// </summary>
    [SerializeField]
    private GameObject npcInDanger;

    /// <summary>
    /// Access the npc in safety gameobject.
    /// </summary>
    [SerializeField]
    private GameObject npcSafe;

    /// <summary>
    /// Access the door animator..
    /// </summary>
    [SerializeField]
    private Animator doorAnimator;

    /// <summary>
    /// Access the fire gameobject.
    /// </summary>
    [SerializeField]
    private GameObject fire;

    /// <summary>
    /// Set the time for the NPC to disappear.
    /// </summary>
    [SerializeField]
    private float timeToDisappear = 5f;

    /// <summary>
    /// Access the score stats scriptableobject.
    /// </summary>
    [SerializeField]
    private ScoreStats scoreStats;

    /// <summary>
    /// Set the name of the animation to be played.
    /// </summary>
    [SerializeField]
    private string doorAnimName;

    /// <summary>
    /// Checks whether the player has won.
    /// </summary>
    private bool hasWon;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        hasWon = false;
    }

    /// <summary>
    /// To be played in every frame of the game.
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

    /// <summary>
    /// The state when nothing has hapenned yet.
    /// </summary>
    private void NoneState()
    {
        obstacle.SetActive(true);
        npcInDanger.SetActive(true);
        npcSafe.SetActive(false);
        fire.SetActive(false);
    }

    /// <summary>
    /// The state when the player won.
    /// </summary>
    private void WonState()
    {
        npcInDanger.SetActive(false);
        fire.SetActive(false);
        if (npcSafe != null)
        {
            npcSafe.SetActive(true);
        }

        doorAnimator.Play(doorAnimName);

        StartCoroutine(Disappear(npcSafe));
    }

    /// <summary>
    /// The state when the player lost.
    /// </summary>
    private void LostState()
    {
        obstacle.SetActive(true);
        npcInDanger.SetActive(false);
        npcSafe.SetActive(false);
        fire.SetActive(true);
    }

    /// <summary>
    /// Disappear the NPC.
    /// </summary>
    /// <param name="gameObject"> The person stuck in the house.</param>
    /// <returns></returns>
    private IEnumerator Disappear(GameObject gameObject)
    {
        WaitForSeconds wfs = new WaitForSeconds(timeToDisappear);

        yield return wfs;

        Destroy(gameObject);

        StopCoroutine(Disappear(gameObject));
    }
}
