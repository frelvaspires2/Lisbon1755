using UnityEngine;
using UnityEngine.AI;
using System.Collections;

/// <summary>
/// The state when the agent is dead.
/// </summary>
public class DeadState : MonoBehaviour, IState
{
    /// <summary>
    /// Access the agent's stats.
    /// </summary>
    [SerializeField]
    private PanickedStats panickedStats;

    /// <summary>
    /// Access the agent's navmesh.
    /// </summary>
    [SerializeField]
    private NavMeshAgent agent;

    /// <summary>
    /// Access the agent's gameobject.
    /// </summary>
    [SerializeField]
    private GameObject agentObject;

    /// <summary>
    /// Where the state is run.
    /// </summary>
    public void State()
    {
        agent.ResetPath();
        agent.radius = 0;
        StartCoroutine(Dying());
        //Debug.Log("State: Dead");
    }

    /// <summary>
    /// The dying process.
    /// </summary>
    /// <returns> Destroys the agent.</returns>
    private IEnumerator Dying()
    {
        WaitForSeconds wfs = new WaitForSeconds(panickedStats.DyingTime);

        yield return wfs;

        Destroy(agentObject);
    }
}
