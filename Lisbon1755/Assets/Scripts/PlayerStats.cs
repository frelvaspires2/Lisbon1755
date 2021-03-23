using UnityEngine;

/// <summary>
/// Player stats.
/// </summary>
[CreateAssetMenu(menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    /// <summary>
    /// Max angular acceleration.
    /// </summary>
    [SerializeField]
    private float maxAngularAcceleration = 90.0f;

    /// <summary>
    /// Gets max angular acceleration.
    /// </summary>
    public float Max_Angular_Acceleration { get => maxAngularAcceleration; }

    /// <summary>
    /// Max forward acceleration.
    /// </summary>
    [SerializeField]
    private float maxForwardAcceleration = 20.0f;

    /// <summary>
    /// Gets max angular acceleration.
    /// </summary>
    public float MaxForwardAcceleration { get => maxForwardAcceleration; }

    /// <summary>
    /// Max backward acceleration.
    /// </summary>
    [SerializeField]
    private float maxBackwardAcceleration = 10.0f;

    /// <summary>
    /// Gets max backward acceleration.
    /// </summary>
    public float MaxBackwardAcceleration { get => maxBackwardAcceleration; }

    /// <summary>
    /// Max strafe acceleration.
    /// </summary>
    [SerializeField]
    private float maxStrafeAcceleration = 15.0f;

    /// <summary>
    /// Gets max strafe acceleration.
    /// </summary>
    public float MaxStrafeAcceleration { get => maxStrafeAcceleration; }

    /// <summary>
    /// Jump acceleration.
    /// </summary>
    [SerializeField]
    private float jumpAcceleration = 500.0f;

    /// <summary>
    /// Gets jump acceleration.
    /// </summary>
    public float JumpAcceleration { get => jumpAcceleration; }

    /// <summary>
    /// Gravity acceleration.
    /// </summary>
    [SerializeField]
    private float gravityAcceleration = 30.0f;

    /// <summary>
    /// Gets gravity acceleration.
    /// </summary>
    public float GravityAcceleration { get => gravityAcceleration; }


    /// <summary>
    /// Mouse angular velocity multiplier.
    /// </summary>
    [SerializeField]
    private float mouseAngularVelocityMult = 5.0f;

    /// <summary>
    /// Gets mouse angular velocity multiplier.
    /// </summary>
    public float MouseAngularVelocityMult { get => mouseAngularVelocityMult; }

    /// <summary>
    /// Max angular velocity.
    /// </summary>
    [SerializeField]
    private float maxAngularVelocity = 50.0f;

    /// <summary>
    /// Gets max angular velocity.
    /// </summary>
    public float MaxAngularVelocity { get => maxAngularVelocity; }

    /// <summary>
    /// Max forward velocity.
    /// </summary>
    [SerializeField]
    private float maxForwardVelocity = 4.0f;

    /// <summary>
    /// Gets max forward velocity.
    /// </summary>
    public float MaxForwardVelocity { get => maxForwardVelocity; }

    /// <summary>
    /// Max backward velocity.
    /// </summary>
    [SerializeField]
    private float maxBackwardVelocity = 2.0f;

    /// <summary>
    /// Gets max backward velocity.
    /// </summary>
    public float MaxBackwardVelocity { get => maxBackwardVelocity; }

    /// <summary>
    /// Max strafe velocity.
    /// </summary>
    [SerializeField]
    private float maxStrafeVelocity = 3.0f;

    /// <summary>
    /// Gets max strafe velocity.
    /// </summary>
    public float MaxStrafeVelocity { get => maxStrafeVelocity; }

    /// <summary>
    /// Max jump velocity.
    /// </summary>
    [SerializeField]
    private float maxJumpVelocity = 30.0f;

    /// <summary>
    /// Gets max jump velocity.
    /// </summary>
    public float MaxJumpVelocity { get => maxJumpVelocity; }

    [SerializeField]
    private float maxFallVelocity = 50.0f;
    public float MaxFallVelocity { get => maxFallVelocity; }


    /// <summary>
    /// Walk velocity multiplier.
    /// </summary>
    [SerializeField]
    private float walkVelocityMult = 1.0f;

    /// <summary>
    /// Gets max velocity multiplier.
    /// </summary>
    public float WalkVelocityMult { get => walkVelocityMult; }

    /// <summary>
    /// Run velocity multiplier.
    /// </summary>
    [SerializeField]
    private float runVelocityMult = 2.0f;

    /// <summary>
    /// Gets run velocity multiplier.
    /// </summary>
    public float RunVelocityMult { get => runVelocityMult; }

    /// <summary>
    /// Roll velicity multiplier.
    /// </summary>
    [SerializeField]
    private float rollVelocityMult = 10.0f;

    /// <summary>
    /// Gets roll velocity multiplier.
    /// </summary>
    public float RollVelocityMult { get => rollVelocityMult; }

    /// <summary>
    /// Roll time.
    /// </summary>
    [SerializeField]
    private float rollTime = 0.5f;

    /// <summary>
    /// Gets roll time.
    /// </summary>
    public float RollTime { get => rollTime; }

    /// <summary>
    /// Translation deceleration.
    /// </summary>
    [SerializeField]
    private float translationDeceleration = 10.0f;

    /// <summary>
    /// Gets the translation decelaration.
    /// </summary>
    public float TransLationDeceleration { get => translationDeceleration; }

    /// <summary>
    /// Max translation velocity.
    /// </summary>
    [SerializeField]
    private float maxTranslationVelocity = 10.0f;

    /// <summary>
    /// Gets the max translation velocity.
    /// </summary>
    public float MaxTranslationVelocity { get => maxTranslationVelocity; }

    /// <summary>
    /// Minimum distance.
    /// </summary>
    [SerializeField]
    private float minDistance = 0.0f;

    /// <summary>
    /// Gets the minimum distance.
    /// </summary>
    public float MinDistance { get => minDistance; }

    /// <summary>
    /// Maximum distance.
    /// </summary>
    [SerializeField]
    private float maxDistance = 10.0f;

    /// <summary>
    /// Gets maximum distance.
    /// </summary>
    public float MaxDistance { get => maxDistance; }

    /// <summary>
    /// Automatic adjust speed.
    /// </summary>
    [SerializeField]
    private float autoAdjustSpeed = 10.0f;

    /// <summary>
    /// Gets automatic adjust speed.
    /// </summary>
    public float AutoAdjustSpeed { get => autoAdjustSpeed; }
}