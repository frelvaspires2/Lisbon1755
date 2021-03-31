using UnityEngine;

public class WoundedState : MonoBehaviour, IState
{
    public void State()
    {
        Debug.Log("State: Wounded");
    }
}
