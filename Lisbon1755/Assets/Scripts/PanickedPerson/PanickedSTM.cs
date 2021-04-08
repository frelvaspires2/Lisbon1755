using UnityEngine;

/// <summary>
/// Main state machine of the panicked person AI.
/// </summary>
public class PanickedSTM : MonoBehaviour
{
    /// <summary>
    /// Access PanickedController script.
    /// </summary>
    [SerializeField]
    private PanickedController panickedController;

    /// <summary>
    /// Access the gameobject's agent.
    /// </summary>
    [SerializeField]
    private GameObject agent;

    /// <summary>
    /// Access the IState interface.
    /// </summary>
    private IState getState;

    /// <summary>
    /// To be played every frame consistely.
    /// </summary>
    private void FixedUpdate()
    {
        STM();
    }

    /// <summary>
    /// Run the state machine.
    /// </summary>
    private void STM()
    {
        switch(panickedController.GetStates)
        {
            case PanickedState.Running:
                getState = gameObject.GetComponent<RunningState>();
                getState.State();
                break;
            case PanickedState.RunningSlower:
                getState = gameObject.GetComponent<SlowerState>();
                getState.State();
                break;
            case PanickedState.WoundedInTheGround:
                getState = gameObject.GetComponent<WoundedState>();
                getState.State();
                break;
            case PanickedState.Dead:
                getState = gameObject.GetComponent<DeadState>();
                getState.State();
                break;
        }
    }
}
