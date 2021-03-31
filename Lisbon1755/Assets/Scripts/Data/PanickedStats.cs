using UnityEngine;

[CreateAssetMenu(menuName = "PanickedStats")]
public class PanickedStats : ScriptableObject
{
    [SerializeField]
    private float health = 100f;

    public float Health { get => health; }

    [SerializeField]
    private float runningSpeed = 5f;

    public float RunningSpeed { get => runningSpeed; }

    [SerializeField]
    private float slowerSpeed = 1f;

    public float SlowerSpeed { get => slowerSpeed; }

    [SerializeField]
    private float dyingTime = 2f;

    public float DyingTime { get => dyingTime; }
}
