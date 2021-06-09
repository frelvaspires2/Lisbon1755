using UnityEngine;

/// <summary>
/// Play the animation when the player enters the area.
/// </summary>
public class PlayAnim : MonoBehaviour
{  
    /// <summary>
    /// Access the player's gameobject.
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// Access the animation controller.
    /// </summary>
    [SerializeField]
    private Animator animController;

    /// <summary>
    /// Insert the animation name.
    /// </summary>
    [SerializeField]
    private string animName;

    /// <summary>
    /// Check whether the animation was already played.
    /// </summary>
    [SerializeField]
    private bool isPlayed;

    /// <summary>
    /// Gets whether the animation already started.
    /// </summary>
    public bool IsPlayed { get => isPlayed; }

    /// <summary>
    /// Check if the animation is finished.
    /// </summary>
    [SerializeField]
    private bool isDone;

    /// <summary>
    /// Gets whether the animation is finished.
    /// </summary>
    public bool IsDone { get => isDone; }

    /// <summary>
    /// Check if the animation has started.
    /// </summary>
    [SerializeField]
    private bool hasStarted;

    /// <summary>
    /// Gets whether the animation has started.
    /// </summary>
    public bool HasStarted { get => hasStarted; }

    /// <summary>
    /// Access the CameraShake script.
    /// </summary>
    [SerializeField]
    private CameraShake cameraShake;

    /// <summary>
    /// Access the fall sound.
    /// </summary>
    [SerializeField]
    private GameObject fallSound;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        isPlayed = false;
        isDone = false;
        animController = GetComponent<Animator>();
        fallSound.SetActive(false);
    }

    /// <summary>
    /// To be played in every frame of the game.
    /// Activate the camera shake.
    /// </summary>
    private void Update()
    {
        if(!isDone && IsPlayed)
        {
            cameraShake.CanShake = true;
        }
    }

    /// <summary>
    /// Detect trigger when enters.
    /// </summary>
    /// <param name="other"> The object collider.</param>
    private void OnTriggerEnter(Collider other)
    {
        // If triggers player and the animation hasn't already played.
        if(other.gameObject == player && !isPlayed)
        {
            // Can't play next time.
            isPlayed = true;
            // Play the animation.
            animController.Play(animName);
            hasStarted = true;
            fallSound.SetActive(true);
        }
    }

    /// <summary>
    /// To be played when the animation is finished.
    /// Update the variables and properties.
    /// </summary>
    public void AnimationDone()
    {
        isDone = true;
        hasStarted = false;
        cameraShake.CanShake = false;
    }
}
