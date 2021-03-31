using UnityEngine;

public class RunningState : MonoBehaviour, IState
{
    public void State()
    {
        Debug.Log("State: Running");
    }
}
