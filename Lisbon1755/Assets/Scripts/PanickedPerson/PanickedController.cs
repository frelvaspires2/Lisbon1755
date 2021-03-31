using UnityEngine;

public class PanickedController : MonoBehaviour
{
    [SerializeField]
    private PanickedStats panickedStats;

    [SerializeField]
    private float health;

    [SerializeField]
    private PanickedState statesEnum;

    public PanickedState GetStates { get => statesEnum; }

    private void Start()
    {
        health = panickedStats.Health;

        statesEnum = PanickedState.Running;
    }

    private void Update()
    {
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(health > 80)
        {
            statesEnum = PanickedState.Running;
        }
        else if(health < 80 && health > 50)
        {
            statesEnum = PanickedState.RunningSlower;
        }
        else if(health <= 50 && health > 0)
        {
            statesEnum = PanickedState.WoundedInTheGround;
        }
        else if (health <= 0)
        {
            statesEnum = PanickedState.Dead;
        }
    }
}
