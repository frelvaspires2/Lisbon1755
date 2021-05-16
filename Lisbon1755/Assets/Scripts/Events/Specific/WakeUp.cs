using System.Collections;
using UnityEngine;

/// <summary>
/// Specific script for wake up event.
/// </summary>
public class WakeUp : MonoBehaviour
{
    /// <summary>
    /// Access the event manager script.
    /// </summary>
    [SerializeField]
    private EventsManager eventManager;

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
    /// Set the time to disappear.
    /// </summary>
    [SerializeField]
    private float timeToDisappear = 5f;

    /// <summary>
    /// Access the animator of the falling building.
    /// </summary>
    [SerializeField]
    private Animator buildingAnim;

    /// <summary>
    /// Name of the animation.
    /// </summary>
    [SerializeField]
    private string animStateName;

    /// <summary>
    /// Access the camera shake script.
    /// </summary>
    [SerializeField]
    private CameraShake cameraShake;

    /// <summary>
    /// Access the EndAnim script.
    /// </summary>
    [SerializeField]
    private EndAnim endAnim;

    [SerializeField]
    private ScoreStats scoreStats;

    private bool hasWon;

    private void Start()
    {
        hasWon = false;
    }

    /// <summary>
    /// To be played in every frame.
    /// </summary>
    private void Update()
    {
        STM();
    }

    /// <summary>
    /// Check which animation state it is.
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
    /// None state method.
    /// </summary>
    private void NoneState()
    {
        npcInDanger.SetActive(true);
        npcSafe.SetActive(false);
        npcDead.SetActive(false);
    }

    /// <summary>
    /// Won state method.
    /// </summary>
    private void WonState()
    {
        npcInDanger.SetActive(false);
        if (npcSafe != null)
        {
            npcSafe.SetActive(true);
        }
        npcDead.SetActive(false);

        StartCoroutine(Disappear(npcSafe));
    }

    /// <summary>
    /// Lost state method.
    /// </summary>
    private void LostState()
    {
        npcInDanger.SetActive(true);
        npcSafe.SetActive(false);
        npcDead.SetActive(false);

        buildingAnim.Play(animStateName);

        if(endAnim.IsAnimationFinished)
        {
            cameraShake.CanShake = false;
            npcInDanger.SetActive(false);
        }
        else
        {
            cameraShake.CanShake = true;
        }
    }

    /// <summary>
    /// Disappear the npc.
    /// </summary>
    /// <param name="gameObject"> Target gameobject.</param>
    /// <returns> Wait for seconds.</returns>
    private IEnumerator Disappear(GameObject gameObject)
    {
        WaitForSeconds wfs = new WaitForSeconds(timeToDisappear);

        yield return wfs;

        Destroy(gameObject);

        StopCoroutine(Disappear(gameObject));
    }
}
