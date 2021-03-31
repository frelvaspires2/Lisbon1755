using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class DeadState : MonoBehaviour, IState
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private GameObject agentObject;

    [SerializeField]
    private float dyingTime = 2f;

    public void State()
    {
        agent.ResetPath();
        StartCoroutine(Dying());
        //Debug.Log("State: Dead");
    }

    private IEnumerator Dying()
    {
        WaitForSeconds wfs = new WaitForSeconds(dyingTime);

        yield return wfs;

        Destroy(agentObject);
    }
}
