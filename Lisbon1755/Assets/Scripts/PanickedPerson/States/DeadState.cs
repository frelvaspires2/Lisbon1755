using UnityEngine;
using UnityEngine.AI;

public class DeadState : MonoBehaviour, IState
{
    [SerializeField]
    private NavMeshAgent agent;

    public void State()
    {
        agent.ResetPath();
        //Debug.Log("State: Dead");
    }
}
