using UnityEngine;
using System.Collections;
using SRandom = System.Random;

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

    [SerializeField]
    private float setShakeDuration;

    [SerializeField]
    private float shakeDuration;

    [SerializeField]
    private int minWaitTime;

    [SerializeField]
    private int maxWaitTime;

    [SerializeField]
    private float waitTime;

    private void Start()
    {
        canRandomShake = false;
        waitTime = 0f;
        shakeDuration = setShakeDuration;
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
        if (canShake)
        {
            InfiniteShake();
        }
        else if (canRandomShake)
        {
            RandomTime();
            RandomShake();
        }
        else if(!canRandomShake)
        {
            shakeDuration = setShakeDuration;
            WaitShake();
        }
    }

    private void RandomTime()
    {
        SRandom rnd = new SRandom();
        waitTime = rnd.Next(minWaitTime, maxWaitTime);
    }

    private void WaitShake()
    {
        if(waitTime > 0)
        {
            waitTime -= Time.deltaTime * 1.0f;
        }
        else
        {
            waitTime = 0f;
            canRandomShake = true;
        }
    }

    private void RandomShake()
    {
        if(shakeDuration > 0)
        {
            InfiniteShake();

            shakeDuration -= Time.deltaTime * 1.0f;
        }
        else
        {
            shakeDuration = 0f;
            camera.localPosition = originalPos;
            canRandomShake = false;
        }
    }

    private IEnumerator Wait()
    {
        WaitForSeconds wfs = new WaitForSeconds(5);

        yield return wfs;

        canRandomShake = true;

        StopCoroutine(Wait());
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
