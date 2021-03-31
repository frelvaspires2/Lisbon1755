using UnityEngine;
using UnityEngine.AI;

public class SlowerState : MonoBehaviour, IState
{
    [SerializeField]
    private PanickedStats panickedStats;

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Transform setDestination;

    public void State()
    {
        agent.destination = setDestination.position;
        agent.speed = panickedStats.SlowerSpeed;
        //Debug.Log("State: Slower");
    }
}
