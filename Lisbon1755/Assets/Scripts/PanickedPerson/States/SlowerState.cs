using UnityEngine;
using UnityEngine.AI;

public class SlowerState : MonoBehaviour, IState
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private Transform setDestination;

    public void State()
    {
        agent.destination = setDestination.position;
        agent.speed = speed;
        //Debug.Log("State: Slower");
    }
}
