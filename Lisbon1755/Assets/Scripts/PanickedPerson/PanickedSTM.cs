using UnityEngine;

public class PanickedSTM : MonoBehaviour
{
    [SerializeField]
    private PanickedController panickedController;

    [SerializeField]
    private DeadState deadState;

    [SerializeField]
    private WoundedState woundedState;

    [SerializeField]
    private SlowerState slowerState;

    [SerializeField]
    private RunningState runningState;

    [SerializeField]
    private GameObject agent;

    private IState getState;

    private void FixedUpdate()
    {
        STM();
    }

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
