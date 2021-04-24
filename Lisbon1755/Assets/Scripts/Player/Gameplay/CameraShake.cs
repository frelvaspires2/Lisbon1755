using UnityEngine;

/// <summary>
/// Shake the camera (to look like an earthquake is happening).
/// </summary>
public class CameraShake : MonoBehaviour
{
    /// <summary>
    /// Turn on/off the shake in inspector (for testing purposes).
    /// </summary>
    [SerializeField]
    private bool canShake;

    /// <summary>
    /// Access the position of the camera.
    /// </summary>
    [SerializeField]
    private Transform camera;

    /// <summary>
    /// Set how violent the shake must be.
    /// </summary>
    [SerializeField]
    private float shakeAmount = 0.7f;

    /// <summary>
    /// Access the coordinates of the original position.
    /// </summary>
    [SerializeField]
    private Vector3 originalPos;

    /// <summary>
    /// Set the original position equal to the camera position.
    /// To be executed when the object becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        originalPos = camera.localPosition;
    }

    /// <summary>
    /// Shake the camera.
    /// To be played in every frame.
    /// </summary>
    private void Update()
    {
        if(canShake)
        {
            camera.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
        }
    }
}
