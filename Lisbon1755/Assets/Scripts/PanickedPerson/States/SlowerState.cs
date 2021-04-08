using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// The state when the agent is wounded.
/// </summary>
public class SlowerState : MonoBehaviour, IState
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
    /// Access the agent's destination.
    /// </summary>
    [SerializeField]
    private Transform setDestination;

    /// <summary>
    /// The state.
    /// </summary>
    public void State()
    {
        agent.destination = setDestination.position;
        agent.speed = panickedStats.SlowerSpeed;
    }
}
