using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField]
    private float maxAngularAcceleration = 90.0f;
    public float Max_Angular_Acceleration { get => maxAngularAcceleration; }

    [SerializeField]
    private float maxForwardAcceleration = 20.0f;
    public float MaxForwardAcceleration { get => maxForwardAcceleration; }

    [SerializeField]
    private float maxBackwardAcceleration = 10.0f;
    public float MaxBackwardAcceleration { get => maxBackwardAcceleration; }

    [SerializeField]
    private float maxStrafeAcceleration = 15.0f;
    public float MaxStrafeAcceleration { get => maxStrafeAcceleration; }

    [SerializeField]
    private float jumpAcceleration = 500.0f;
    public float JumpAcceleration { get => jumpAcceleration; }

    [SerializeField]
    private float gravityAcceleration = 30.0f;
    public float GravityAcceleration { get => gravityAcceleration; }


    [SerializeField]
    private float mouseAngularVelocityMult = 5.0f;
    public float MouseAngularVelocityMult { get => mouseAngularVelocityMult; }

    [SerializeField]
    private float maxAngularVelocity = 50.0f;
    public float MaxAngularVelocity { get => maxAngularVelocity; }

    [SerializeField]
    private float maxForwardVelocity = 4.0f;
    public float MaxForwardVelocity { get => maxForwardVelocity; }

    [SerializeField]
    private float maxBackwardVelocity = 2.0f;
    public float MaxBackwardVelocity { get => maxBackwardVelocity; }

    [SerializeField]
    private float maxStrafeVelocity = 3.0f;
    public float MaxStrafeVelocity { get => maxStrafeVelocity; }

    [SerializeField]
    private float maxJumpVelocity = 30.0f;
    public float MaxJumpVelocity { get => maxJumpVelocity; }

    [SerializeField]
    private float maxFallVelocity = 50.0f;
    public float MaxFallVelocity { get => maxFallVelocity; }


    [SerializeField]
    private float walkVelocityMult = 1.0f;
    public float WalkVelocityMult { get => walkVelocityMult; }

    [SerializeField]
    private float runVelocityMult = 2.0f;
    public float RunVelocityMult { get => runVelocityMult; }
}
