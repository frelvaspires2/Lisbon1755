using UnityEngine;

public class SlowerState : MonoBehaviour, IState
{
    public void State()
    {
        Debug.Log("State: Slower");
    }
}
