using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerStats playerStats;

    private CharacterController controller;
    private Vector3 acceleration;
    private Vector3 velocity;
    private Vector3 motion;
    private float   angularAcceleration;
    private float   angularVelocity;
    private float   angularMotion;
    private float   velocityMult;
    private bool    jump;
    private bool    autoMove;
    private bool    mouseMove;

    private void Start()
    {
        Cursor.lockState        = CursorLockMode.Confined;
        controller             = GetComponent<CharacterController>();
        acceleration           = Vector3.zero;
        velocity               = Vector3.zero;
        motion                 = Vector3.zero;
        angularAcceleration    = 0f;
        angularVelocity        = 0f;
        angularMotion          = 0f;
        velocityMult           = playerStats.WalkVelocityMult;
        jump                   = false;
        autoMove               = false;
        mouseMove              = false;
    }

    private void Update()
    {
        CheckForJump();
        CheckForRoll();
        CheckForAutoMove();
        CheckForMouseMove();
        CheckForSpeedToggle();
        UpdateMouseCursor();
        UpdateRotation();
    }

    private void CheckForJump()
    {
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
            jump = true;
    }

    private void CheckForAutoMove()
    {
        if (Input.GetButtonDown("AutoMove"))
            autoMove = !autoMove;
        else if (mouseMove || Input.GetAxis("Forward") != 0f)
            autoMove = false;
    }

    private void CheckForMouseMove()
    {
        mouseMove = (Input.GetMouseButton(0) && Input.GetMouseButton(1)) ||
            Input.GetMouseButton(2);
    }

    private void CheckForSpeedToggle()
    {
        if (Input.GetButtonDown("ToggleWalkSpeed"))
        {
            velocityMult = (velocityMult == playerStats.WalkVelocityMult) ?
                playerStats.RunVelocityMult : playerStats.WalkVelocityMult;
        }
        else if (Input.GetButtonUp("ToggleWalkSpeed"))
        {
            velocityMult = 1f;
        }
    }

    private void UpdateRotation()
    {
        if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
            UpdateMouseRotation();
        else
            UpdateKeyboardRotation();
    }

    private void UpdateMouseCursor()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            Cursor.lockState = CursorLockMode.Locked;
        else if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2))
            if (!Input.GetMouseButton(1) && !Input.GetMouseButton(2))
                Cursor.lockState = CursorLockMode.Confined;
    }

    private void UpdateMouseRotation()
    {
        angularMotion = Input.GetAxis("Mouse X") * 
            playerStats.MouseAngularVelocityMult;
        transform.Rotate(0f, angularMotion, 0f);
    }

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

    private void FixedUpdate()
    {
        UpdateAcceleration();
        UpdateVelocity();
        UpdatePosition();
    }

    private void UpdateAcceleration()
    {
        acceleration.z = autoMove || mouseMove ? 1f : Input.GetAxis("Forward");
        acceleration.z *= (acceleration.z > 0 ? 
            playerStats.MaxForwardAcceleration : 
            playerStats.MaxBackwardAcceleration) * velocityMult;

        acceleration.x = Input.GetAxis("Strafe") *
            playerStats.MaxStrafeAcceleration * velocityMult;

        // jump
        if (jump)
        {
            acceleration.y = playerStats.JumpAcceleration;
            jump = false;
        }
        else if (controller.isGrounded)
            acceleration.y = 0f;
        else
            acceleration.y = -playerStats.GravityAcceleration;
    }

    private void UpdateVelocity()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        
        velocity.z = (acceleration.z == 0f) ? 0f : Mathf.Clamp(velocity.z,
            -playerStats.MaxBackwardVelocity * velocityMult,
            playerStats.MaxForwardVelocity * velocityMult);
        velocity.x = (acceleration.x == 0f) ? 0f : Mathf.Clamp(velocity.x,
            -playerStats.MaxStrafeVelocity * velocityMult,
            playerStats.MaxStrafeVelocity * velocityMult);
        velocity.y = (acceleration.y == 0f) ? -0.1f : Mathf.Clamp(
            velocity.y, -playerStats.MaxFallVelocity,
            playerStats.MaxJumpVelocity);
    }

    private void UpdatePosition()
    {
        motion = transform.TransformVector(velocity * Time.fixedDeltaTime);

        controller.Move(motion);
    }

    private void CheckForRoll()
    {
        if (Input.GetButtonUp("Roll"))
        {
            StartCoroutine(RollRoutine());
        }
    }

    private IEnumerator RollRoutine()
    {
        WaitForSeconds wfs = new WaitForSeconds(0.5f);

        velocityMult = (velocityMult == playerStats.WalkVelocityMult) ?
                playerStats.RollVelocityMult : playerStats.WalkVelocityMult;

        yield return wfs;

        velocityMult = 1.0f;

        StopCoroutine(RollRoutine());
    }
}
