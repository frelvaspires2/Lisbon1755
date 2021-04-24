using UnityEngine;
using LibGameAI.FSMs;
using System;


public class PanickedBehavior : MonoBehaviour
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

    // Reference to the state machine.
    private StateMachine stateMachine;

    /// <summary>
    /// To be played in the first frame.
    /// Create the state machine.
    /// </summary>
    private void Start()
    {
        // Create the running state.
        getState = GetComponent<RunningState>();
        State runningState = new State("Running",
            () => Debug.Log("Enter on running state"),
            getState.State,
            () => Debug.Log("Leave running state"));

        // Create the slower state.
        getState = GetComponent<SlowerState>();
        State runningSlower = new State("Running slower",
            () => Debug.Log("Enter on slower state"),
            getState.State,
            () => Debug.Log("Leave slower state"));

        // Create the wounded state.
        getState = GetComponent<WoundedState>();
        State woundedState = new State("Wounded in the ground",
            () => Debug.Log("Enter on wounded state"),
            getState.State,
            () => Debug.Log("Leave wounded state"));

        // Create the dead state.
        getState = GetComponent<DeadState>();
        State deadState = new State("Dead",
            () => Debug.Log("Enter on dead state"),
            getState.State,
            () => Debug.Log("Leave dead state"));


        // Add the transitions.

        // Running to slower.
        runningState.AddTransition(
            new Transition(
                () =>
                panickedController.GetStates == PanickedState.RunningSlower,
                () => Debug.Log("Agent got hit"),
                runningSlower));

        // Running to wounded.
        runningState.AddTransition(
         new Transition(
             () =>
             panickedController.GetStates == PanickedState.WoundedInTheGround,
             () => Debug.Log("Agent got wounded"),
             woundedState));

        // Running to dead.
        runningState.AddTransition(
         new Transition(
             () =>
             panickedController.GetStates == PanickedState.Dead,
             () => Debug.Log("Agent got killed"),
             deadState));

        // Slower to running.
        runningSlower.AddTransition(
         new Transition(
             () =>
             panickedController.GetStates == PanickedState.Running,
             () => Debug.Log("Agent recovered."),
             runningState));

        // Slower to wounded.
        runningSlower.AddTransition(
         new Transition(
             () =>
             panickedController.GetStates == PanickedState.WoundedInTheGround,
             () => Debug.Log("Agent got wounded"),
             runningState));

        // Slower to dead.
        runningSlower.AddTransition(
         new Transition(
             () =>
             panickedController.GetStates == PanickedState.Dead,
             () => Debug.Log("Agent got killed"),
             runningState));

        // Wounded to running.
        woundedState.AddTransition(
         new Transition(
             () =>
             panickedController.GetStates == PanickedState.Running,
             () => Debug.Log("Agent recovered."),
             runningState));

        // Wounded to slower.
        woundedState.AddTransition(
         new Transition(
             () =>
             panickedController.GetStates == PanickedState.RunningSlower,
             () => Debug.Log("Agent recovered a bit."),
             runningSlower));

        // Wounded to dead.
        woundedState.AddTransition(
         new Transition(
             () =>
             panickedController.GetStates == PanickedState.Dead,
             () => Debug.Log("Agent got killed."),
             runningState));

        // Create the state machine and set the initial state.
        stateMachine = new StateMachine(runningState);
    }

    /// <summary>
    /// To be played in every frame.
    /// Run the state machine.
    /// </summary>
    private void Update()
    {
        Action actions = stateMachine.Update();
        actions?.Invoke();
    }
}
