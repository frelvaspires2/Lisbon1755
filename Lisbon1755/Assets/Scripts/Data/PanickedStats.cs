using UnityEngine;

/// <summary>
/// Stats for the panicked person agent.
/// </summary>
[CreateAssetMenu(menuName = "PanickedStats")]
public class PanickedStats : ScriptableObject
{
    /// <summary>
    /// Health.
    /// </summary>
    [SerializeField]
    private float health = 100f;

    /// <summary>
    /// Gets health.
    /// </summary>
    public float Health { get => health; }

    /// <summary>
    /// Running speed.
    /// </summary>
    [SerializeField]
    private float runningSpeed = 5f;

    /// <summary>
    /// Gets running speed.
    /// </summary>
    public float RunningSpeed { get => runningSpeed; }

    /// <summary>
    /// Slower speed.
    /// </summary>
    [SerializeField]
    private float slowerSpeed = 1f;

    /// <summary>
    /// Gets slower speed.
    /// </summary>
    public float SlowerSpeed { get => slowerSpeed; }

    /// <summary>
    /// Dying time.
    /// </summary>
    [SerializeField]
    private float dyingTime = 2f;

    /// <summary>
    /// Gets dying time.
    /// </summary>
    public float DyingTime { get => dyingTime; }
}
