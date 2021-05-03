using UnityEngine;
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

    /// <summary>
    /// Check whether a random shake will happen.
    /// </summary>
    [SerializeField]
    private bool canRandomShake;

    /// <summary>
    /// Set the random shake time.
    /// </summary>
    [SerializeField]
    private float setShakeDuration;

    /// <summary>
    /// Track the random shake duration.
    /// </summary>
    [SerializeField]
    private float shakeDuration;

    /// <summary>
    /// Set the minimum time to start a random shake.
    /// </summary>
    [SerializeField]
    private int minWaitTime;

    /// <summary>
    /// Set the maximum time to start a random shake.
    /// </summary>
    [SerializeField]
    private int maxWaitTime;

    /// <summary>
    /// Track the time for the random shake.
    /// </summary>
    [SerializeField]
    private float waitTime;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize variables.
    /// </summary>
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
        /*else if (canRandomShake)
        {
            RandomTime();
            RandomShake();
        }
        else if(!canRandomShake)
        {
            shakeDuration = setShakeDuration;
            WaitShake();
        }*/
    }

    /// <summary>
    /// Set a random time to shake the camera.
    /// </summary>
    private void RandomTime()
    {
        SRandom rnd = new SRandom();
        waitTime = rnd.Next(minWaitTime, maxWaitTime);
    }

    /// <summary>
    /// Wait for the camera to shake (random shake).
    /// </summary>
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

    /// <summary>
    /// Random shake.
    /// </summary>
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

    /// <summary>
    /// Shake.
    /// </summary>
    private void InfiniteShake()
    {
        camera.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
    }
}
