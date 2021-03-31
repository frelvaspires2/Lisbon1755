using UnityEngine;
using UnityEngine.AI;

public class RunningState : MonoBehaviour, IState
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Transform setDestination;

    [SerializeField]
    private float speed = 5f;

    public void State()
    {
        agent.destination = setDestination.position;
        agent.speed = speed;

        //Debug.Log("State: Running");
    }
}
