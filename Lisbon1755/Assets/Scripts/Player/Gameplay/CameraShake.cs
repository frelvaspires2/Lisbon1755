using UnityEngine;
using System.Collections;

/// <summary>
/// Shake the camera (to look like an earthquake is happening).
/// </summary>
public class CameraShake : MonoBehaviour
{
    /// <summary>
    /// Check whether the camera can shake.
    /// </summary>
    [SerializeField]
    private bool canShake;

    /// <summary>
    /// Gets or sets whether the camera can shake.
    /// </summary>
    public bool CanShake
    {
        get => canShake;
        set => canShake = value;
    }

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
    private Vector3 originalPos;

    [SerializeField]
    private bool canRandomShake;

    private void Start()
    {
        canRandomShake = false;
    }

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
            InfiniteShake();
        }
        else if(canRandomShake)
        {
            StartCoroutine(ShakeRoutine());
            InfiniteShake();
        }
    }

    private void InfiniteShake()
    {
            camera.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
    }

    private IEnumerator ShakeRoutine()
    {
        WaitForSeconds wfs = new WaitForSeconds(2);

        yield return wfs;

        canRandomShake = false;

        StopCoroutine(ShakeRoutine());
    }
}
