using System.Collections;
using UnityEngine;

public class WakeUp : MonoBehaviour
{
    [SerializeField]
    private EventsManager eventManager;

    [SerializeField]
    private GameObject npcInDanger;

    [SerializeField]
    private GameObject npcSafe;

    [SerializeField]
    private GameObject npcDead;

    [SerializeField]
    private float timeToDisappear = 5f;

    [SerializeField]
    private Animator buildingAnim;

    [SerializeField]
    private string animStateName;

    [SerializeField]
    private CameraShake cameraShake;

    [SerializeField]
    private EndAnim endAnim;

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
        npcInDanger.SetActive(true);
        npcSafe.SetActive(false);
        npcDead.SetActive(false);
    }

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

    private IEnumerator Disappear(GameObject gameObject)
    {
        WaitForSeconds wfs = new WaitForSeconds(timeToDisappear);

        yield return wfs;

        Destroy(gameObject);

        StopCoroutine(Disappear(gameObject));
    }
}
