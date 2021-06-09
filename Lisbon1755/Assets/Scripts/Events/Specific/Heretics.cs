using System.Collections;
using UnityEngine;

/// <summary>
/// Heretic event specific stuff.
/// </summary>
public class Heretics : MonoBehaviour
{
    /// <summary>
    /// Access the EventsManager.
    /// </summary>
    [SerializeField]
    private EventsManager eventManager;

    /// <summary>
    /// Access the stick gameobject.
    /// </summary>
    [SerializeField]
    private GameObject stick;

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
    /// Access the dead npc gameobject.
    /// </summary>
    [SerializeField]
    private GameObject npcDead;

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
    /// Checks whether the player has won.
    /// </summary>
    private bool hasWon;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize stuff.
    /// </summary>
    private void Start()
    {
        hasWon = false;
        fire.SetActive(false);
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

    /// <summary>
    /// The state when nothing has hapenned yet.
    /// </summary>
    private void NoneState()
    {
        stick.SetActive(true);
        npcInDanger.SetActive(true);
        npcSafe.SetActive(false);
        npcDead.SetActive(false);
    }

    /// <summary>
    /// The state when the player won.
    /// </summary>
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

    /// <summary>
    /// The state when the player lost.
    /// </summary>
    private void LostState()
    {
        stick.SetActive(true);
        npcInDanger.SetActive(false);
        npcSafe.SetActive(false);
        npcDead.SetActive(true);
        fire.SetActive(true);
    }

    /// <summary>
    /// Disappear the NPC.
    /// </summary>
    /// <param name="gameObject"> The heretic.</param>
    /// <returns> Wait for seconds.</returns>
    private IEnumerator Disappear(GameObject gameObject)
    {
        WaitForSeconds wfs = new WaitForSeconds(timeToDisappear);

        yield return wfs;

        Destroy(gameObject);

        StopCoroutine(Disappear(gameObject));
    }
}
