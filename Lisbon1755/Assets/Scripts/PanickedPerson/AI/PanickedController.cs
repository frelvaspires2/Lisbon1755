using UnityEngine;

/// <summary>
/// Controller of the state machine.
/// </summary>
public class PanickedController : MonoBehaviour
{
    /// <summary>
    /// Access the stats of the agent.
    /// </summary>
    [SerializeField]
    private PanickedStats panickedStats;

    /// <summary>
    /// Track the health.
    /// </summary>
    [SerializeField]
    private float health;

    public float Health { get => health; set => health = value; }

    /// <summary>
    /// Access the states enums.
    /// </summary>
    [SerializeField]
    private PanickedState statesEnum;

    /// <summary>
    /// Gets the states enums.
    /// </summary>
    public PanickedState GetStates { get => statesEnum; }

    /// <summary>
    /// Access the animation controller script.
    /// </summary>
    [SerializeField]
    private PanickAnimController panickAnimController;

    /// <summary>
    /// Access the sound controller script.
    /// </summary>
    [SerializeField]
    private AISoundController aiSoundController;

    /// <summary>
    /// To be played in the first frame.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        health = panickedStats.Health;

        statesEnum = PanickedState.Running;
    }

    /// <summary>
    /// To be played in every frame.
    /// </summary>
    private void Update()
    {
        CheckHealth();
    }

    /// <summary>
    /// Check the agent's health.
    /// </summary>
    private void CheckHealth()
    {
        if(health > (panickedStats.Health / 1.3f))
        {
            statesEnum = PanickedState.Running;
            panickAnimController.GetSetPanickAnimTypes = PanickAnimTypes.Running;
            aiSoundController.GetSetAISoundTypes = AISoundTypes.Running;
           
        }
        else if(health < (panickedStats.Health / 1.3f) &&
            health > (panickedStats.Health / 2f))
        {
            statesEnum = PanickedState.RunningSlower;
            panickAnimController.GetSetPanickAnimTypes = PanickAnimTypes.RunningSlower;
            aiSoundController.GetSetAISoundTypes = AISoundTypes.RunningSlow;
        }
        else if(health <= (panickedStats.Health / 2f) && health > 0)
        {
            statesEnum = PanickedState.WoundedInTheGround;
            panickAnimController.GetSetPanickAnimTypes = PanickAnimTypes.Wounded;
            aiSoundController.GetSetAISoundTypes = AISoundTypes.Wounded;
        }
        else if (health <= 0)
        {
            statesEnum = PanickedState.Dead;
            panickAnimController.GetSetPanickAnimTypes = PanickAnimTypes.Dying;
            aiSoundController.GetSetAISoundTypes = AISoundTypes.Dying;
        }
    }
}
