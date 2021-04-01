using UnityEngine;
using System.Collections;

/// <summary>
/// Player movement (walk, run, jump and roll.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// Access the player animation types enum.
    /// </summary>
    [SerializeField]
    private PlayerAnimTypes playerAnimTypes;

    /// <summary>
    /// Gets the player animation types enum.
    /// </summary>
    public PlayerAnimTypes GetPlayerAnimTypes { get => playerAnimTypes; }

    /// <summary>
    /// Access PlayerStats scriptableobject.
    /// </summary>
    [SerializeField]
    private PlayerStats playerStats;

    /// <summary>
    /// Access PlayerHealth script.
    /// </summary>
    [SerializeField]
    private PlayerHealth playerHealth;

    /// <summary>
    /// Access PlayerEnergy script.
    /// </summary>
    [SerializeField]
    private PlayerEnergy playerEnergy;

    /// <summary>
    /// Access CharacterController.
    /// </summary>
    private CharacterController controller;

    /// <summary>
    /// Acceleration.
    /// </summary>
    private Vector3 acceleration;

    /// <summary>
    /// Velocity.
    /// </summary>
    private Vector3 velocity;

    /// <summary>
    /// Motion.
    /// </summary>
    private Vector3 motion;

    /// <summary>
    /// Angular acceleration.
    /// </summary>
    private float angularAcceleration;

    /// <summary>
    /// Angular velocity.
    /// </summary>
    private float angularVelocity;

    /// <summary>
    /// Angular motion.
    /// </summary>
    private float angularMotion;

    /// <summary>
    /// Velocity multiplier.
    /// </summary>
    private float velocityMult;

    /// <summary>
    /// Velocity multiplier when injured.
    /// </summary>
    private float injuryVelocityMult;

    /// <summary>
    /// Check for jump.
    /// </summary>
    private bool jump;

    /// <summary>
    /// Check if can jump.
    /// </summary>
    private bool canJump;

    /// <summary>
    /// Check if can roll.
    /// </summary>
    private bool canRoll;

    /// <summary>
    /// Check for auto movement.
    /// </summary>
    private bool autoMove;

    /// <summary>
    /// Check for mouse movement.
    /// </summary>
    private bool mouseMove;

    /// <summary>
    /// The first frame of the game.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        controller = GetComponent<CharacterController>();
        acceleration = Vector3.zero;
        velocity = Vector3.zero;
        motion = Vector3.zero;
        angularAcceleration = 0f;
        angularVelocity = 0f;
        angularMotion = 0f;
        velocityMult = playerStats.WalkVelocityMult;
        injuryVelocityMult = playerStats.InjuredWalkMult;
        jump = false;
        canJump = true;
        canRoll = true;
        autoMove = false;
        mouseMove = false;
    }

    /// <summary>
    /// To be played every frame.
    /// </summary>
    private void Update()
    {
        CallAnimations();
        CheckForJump();
        CheckForRoll();
        CheckForAutoMove();
        CheckForMouseMove();
        CheckForSpeedToggle();
        UpdateMouseCursor();
        UpdateRotation();
    }

    /// <summary>
    /// Check for jump.
    /// </summary>
    private void CheckForJump()
    {
        if (controller.isGrounded && Input.GetButtonDown("Jump") && canJump)
        {
            canRoll = false;
            jump = true;
        }
    }

    /// <summary>
    /// Check for auto movement.
    /// </summary>
    private void CheckForAutoMove()
    {
        if (Input.GetButtonDown("AutoMove"))
        {
            autoMove = !autoMove;
        }
        else if (mouseMove || Input.GetAxis("Forward") != 0f)
        {
            autoMove = false;
        }
    }

    /// <summary>
    /// Check for mouse movement.
    /// </summary>
    private void CheckForMouseMove()
    {
        mouseMove = (Input.GetMouseButton(0) && Input.GetMouseButton(1)) ||
            Input.GetMouseButton(2);
    }

    /// <summary>
    /// Check for speed toggle.
    /// </summary>
    private void CheckForSpeedToggle()
    {
        if (Input.GetButtonDown("ToggleWalkSpeed"))
        {
            if (playerHealth.IsInjured)
            {
                injuryVelocityMult = (injuryVelocityMult ==
                    playerStats.InjuredWalkMult) ?
                                              playerStats.InjuredRunMult :
                                              playerStats.InjuredWalkMult;
            }
            else
            {
                velocityMult = (velocityMult == playerStats.WalkVelocityMult) ?
                                playerStats.RunVelocityMult :
                                playerStats.WalkVelocityMult;
            }
        }
        else if (Input.GetButtonUp("ToggleWalkSpeed"))
        {
            if (playerHealth.IsInjured)
            {
                injuryVelocityMult = playerStats.InjuredWalkMult;
            }
            else
            {
                velocityMult = playerStats.WalkVelocityMult;
            }
        }
    }

    /// <summary>
    /// Update rotation.
    /// </summary>
    private void UpdateRotation()
    {
        if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            UpdateMouseRotation();
        }
        else
        {
            UpdateKeyboardRotation();
        }
    }

    /// <summary>
    /// Update mouse cursor.
    /// </summary>
    private void UpdateMouseCursor()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            Cursor.lockState = CursorLockMode.Locked;
        else if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2))
            if (!Input.GetMouseButton(1) && !Input.GetMouseButton(2))
                Cursor.lockState = CursorLockMode.Confined;
    }

    /// <summary>
    /// Update mouse rotation.
    /// </summary>
    private void UpdateMouseRotation()
    {
        angularMotion = Input.GetAxis("Mouse X") *
            playerStats.MouseAngularVelocityMult;
        transform.Rotate(0f, angularMotion, 0f);
    }

    /// <summary>
    /// Update keyboard rotation.
    /// </summary>
    private void UpdateKeyboardRotation()
    {

        angularAcceleration = Input.GetAxis("Rotate") *
            playerStats.Max_Angular_Acceleration * velocityMult;

        angularVelocity += angularAcceleration * Time.deltaTime;
        angularVelocity = (angularAcceleration == 0f) ? 0f : Mathf.Clamp
            (angularVelocity, -playerStats.MaxAngularVelocity,
            playerStats.MaxAngularVelocity) * velocityMult;

        angularMotion = angularVelocity * Time.deltaTime;
        transform.Rotate(0f, angularMotion, 0f);
    }

    /// <summary>
    /// To be played every frame consistenly.
    /// </summary>
    private void FixedUpdate()
    {
        UpdateAcceleration();
        UpdateVelocity();
        UpdatePosition();
    }

    /// <summary>
    /// Update acceleration.
    /// </summary>
    private void UpdateAcceleration()
    {
        acceleration.z = autoMove || mouseMove ? 1f : Input.GetAxis("Forward");

        acceleration.x = Input.GetAxis("Strafe");

        if (playerHealth.IsInjured)
        {
            acceleration.z *= (acceleration.z > 0 ?
                playerStats.MaxForwardAcceleration :
                playerStats.MaxBackwardAcceleration) * injuryVelocityMult;

            acceleration.x *= playerStats.MaxStrafeAcceleration * 
                injuryVelocityMult;
        }
        else
        {
            acceleration.z *= (acceleration.z > 0 ?
                playerStats.MaxForwardAcceleration :
                playerStats.MaxBackwardAcceleration) * velocityMult;

            acceleration.x *= playerStats.MaxStrafeAcceleration * velocityMult;
        }

        if (jump && !playerHealth.IsInjured)
        {
            acceleration.y = playerStats.JumpAcceleration;
            jump = false;
        }
        else if (controller.isGrounded)
        {
            acceleration.y = 0f;
            canRoll = true;
        }
        else
        {
            acceleration.y = -playerStats.GravityAcceleration;
        }
    }

    /// <summary>
    /// Update velocity.
    /// </summary>
    private void UpdateVelocity()
    {
        velocity += acceleration * Time.fixedDeltaTime;

        if (playerHealth.IsInjured)
        {
            velocity.z = (acceleration.z == 0f) ? 0f : Mathf.Clamp(velocity.z,
                -playerStats.MaxBackwardVelocity * injuryVelocityMult,
                playerStats.MaxForwardVelocity * injuryVelocityMult);
            velocity.x = (acceleration.x == 0f) ? 0f : Mathf.Clamp(velocity.x,
                -playerStats.MaxStrafeVelocity * injuryVelocityMult,
                playerStats.MaxStrafeVelocity * injuryVelocityMult);
        }
        else
        {
            velocity.z = (acceleration.z == 0f) ? 0f : Mathf.Clamp(velocity.z,
                -playerStats.MaxBackwardVelocity * velocityMult,
                playerStats.MaxForwardVelocity * velocityMult);
            velocity.x = (acceleration.x == 0f) ? 0f : Mathf.Clamp(velocity.x,
                -playerStats.MaxStrafeVelocity * velocityMult,
                playerStats.MaxStrafeVelocity * velocityMult);
        }

        velocity.y = (acceleration.y == 0f) ? -0.1f : Mathf.Clamp(
              velocity.y, -playerStats.MaxFallVelocity,
              playerStats.MaxJumpVelocity);
    }

    /// <summary>
    /// Update position.
    /// </summary>
    private void UpdatePosition()
    {
        motion = transform.TransformVector(velocity * Time.fixedDeltaTime);

        controller.Move(motion);
    }

    /// <summary>
    /// Check for roll.
    /// </summary>
    private void CheckForRoll()
    {
        if (Input.GetButtonUp("Roll") && canRoll && !playerHealth.IsInjured &&
            playerEnergy.Energy >= playerStats.EnergyCost)
        {
            canJump = false;
            playerEnergy.Energy -= playerStats.EnergyCost;
            StartCoroutine(RollRoutine());
        }
    }

    private void CallAnimations()
    {
        // walk...
        if (Input.GetAxis("Forward") > 0)
        {
            playerAnimTypes = PlayerAnimTypes.walk;
        }
        // jump
        else if(Input.GetButton("Jump"))
        {
            playerAnimTypes = PlayerAnimTypes.jump;
        }
        // nothing else
        else
        {
            playerAnimTypes = PlayerAnimTypes.idle;
        }
    }

    /// <summary>
    /// Roll routine.
    /// Roll happens here.
    /// </summary>
    /// <returns> Wait for x seconds. </returns>
    private IEnumerator RollRoutine()
    {
        WaitForSeconds wfs = new WaitForSeconds(playerStats.RollTime);

        velocityMult = (velocityMult == playerStats.WalkVelocityMult) ?
                playerStats.RollVelocityMult : playerStats.WalkVelocityMult;

        yield return wfs;

        velocityMult = playerStats.WalkVelocityMult;

        canJump = true;

        StopCoroutine(RollRoutine());
    }

    private IEnumerator ReturnToIdle(float time)
    {
        WaitForSeconds wfs = new WaitForSeconds(time);

        yield return wfs;

        playerAnimTypes = PlayerAnimTypes.idle;

        StopCoroutine(ReturnToIdle(time));
    }
}
