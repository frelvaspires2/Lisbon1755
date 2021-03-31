using UnityEngine;

public class DeadState : MonoBehaviour, IState
{
    public void State()
    {
        Debug.Log("State: Dead");
    }
}
