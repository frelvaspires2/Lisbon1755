using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// The state when the agent is severely wounded.
/// </summary>
public class WoundedState : MonoBehaviour, IState
{
    /// <summary>
    /// Access the agent's navmesh.
    /// </summary>
    [SerializeField]
    private NavMeshAgent agent;

    /// <summary>
    /// The state.
    /// </summary>
    public void State()
    {
        agent.ResetPath();
    }
}
