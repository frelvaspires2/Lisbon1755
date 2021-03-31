using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class DeadState : MonoBehaviour, IState
{
    [SerializeField]
    private PanickedStats panickedStats;

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private GameObject agentObject;

    public void State()
    {
        agent.ResetPath();
        StartCoroutine(Dying());
        //Debug.Log("State: Dead");
    }

    private IEnumerator Dying()
    {
        WaitForSeconds wfs = new WaitForSeconds(panickedStats.DyingTime);

        yield return wfs;

        Destroy(agentObject);
    }
}
