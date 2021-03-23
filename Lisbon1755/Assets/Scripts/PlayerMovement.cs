using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerStats playerStats;

    private CharacterController _controller;
    private Vector3 _acceleration;
    private Vector3 _velocity;
    private Vector3 _motion;
    private float   _angularAcceleration;
    private float   _angularVelocity;
    private float   _angularMotion;
    private float   _velocityMult;
    private bool    _jump;
    private bool    _autoMove;
    private bool    _mouseMove;

    void Start()
    {
        Cursor.lockState        = CursorLockMode.Confined;
        _controller             = GetComponent<CharacterController>();
        _acceleration           = Vector3.zero;
        _velocity               = Vector3.zero;
        _motion                 = Vector3.zero;
        _angularAcceleration    = 0f;
        _angularVelocity        = 0f;
        _angularMotion          = 0f;
        _velocityMult           = playerStats.WalkVelocityMult;
        _jump                   = false;
        _autoMove               = false;
        _mouseMove              = false;
    }

    void Update()
    {
        CheckForJump();
        CheckForAutoMove();
        CheckForMouseMove();
        CheckForSpeedToggle();
        UpdateMouseCursor();
        UpdateRotation();
    }

    private void CheckForJump()
    {
        if (_controller.isGrounded && Input.GetButtonDown("Jump"))
            _jump = true;
    }

    private void CheckForAutoMove()
    {
        if (Input.GetButtonDown("AutoMove"))
            _autoMove = !_autoMove;
        else if (_mouseMove || Input.GetAxis("Forward") != 0f)
            _autoMove = false;
    }

    private void CheckForMouseMove()
    {
        _mouseMove = (Input.GetMouseButton(0) && Input.GetMouseButton(1)) ||
            Input.GetMouseButton(2);
    }

    private void CheckForSpeedToggle()
    {
        if (Input.GetButtonDown("ToggleWalkSpeed"))
        {
            _velocityMult = (_velocityMult == playerStats.WalkVelocityMult) ?
                playerStats.RunVelocityMult : playerStats.WalkVelocityMult;
        }
        else if (Input.GetButtonUp("ToggleWalkSpeed"))
        {
            _velocityMult = 1f;
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
        _angularMotion = Input.GetAxis("Mouse X") * 
            playerStats.MouseAngularVelocityMult;
        transform.Rotate(0f, _angularMotion, 0f);
    }

    private void UpdateKeyboardRotation()
    {
        _angularAcceleration = Input.GetAxis("Rotate") * 
            playerStats.Max_Angular_Acceleration * _velocityMult;

        _angularVelocity += _angularAcceleration * Time.deltaTime;
        _angularVelocity = (_angularAcceleration == 0f) ? 0f : Mathf.Clamp
            (_angularVelocity, -playerStats.MaxAngularVelocity, 
            playerStats.MaxAngularVelocity) * _velocityMult;

        _angularMotion = _angularVelocity * Time.deltaTime;
        transform.Rotate(0f, _angularMotion, 0f);
    }

    void FixedUpdate()
    {
        UpdateAcceleration();
        UpdateVelocity();
        UpdatePosition();
    }

    private void UpdateAcceleration()
    {
        _acceleration.z = _autoMove || _mouseMove ? 1f : Input.GetAxis("Forward");
        _acceleration.z *= (_acceleration.z > 0 ? 
            playerStats.MaxForwardAcceleration : 
            playerStats.MaxBackwardAcceleration) * _velocityMult;

        _acceleration.x = Input.GetAxis("Strafe") *
            playerStats.MaxStrafeAcceleration * _velocityMult;

        if (_jump)
        {
            _acceleration.y = playerStats.JumpAcceleration;
            _jump = false;
        }
        else if (_controller.isGrounded)
            _acceleration.y = 0f;
        else
            _acceleration.y = -playerStats.GravityAcceleration;
    }

    private void UpdateVelocity()
    {
        _velocity += _acceleration * Time.fixedDeltaTime;
        
        _velocity.z = (_acceleration.z == 0f) ? 0f : Mathf.Clamp(_velocity.z,
            -playerStats.MaxBackwardVelocity * _velocityMult,
            playerStats.MaxForwardVelocity * _velocityMult);
        _velocity.x = (_acceleration.x == 0f) ? 0f : Mathf.Clamp(_velocity.x,
            -playerStats.MaxStrafeVelocity * _velocityMult,
            playerStats.MaxStrafeVelocity * _velocityMult);
        _velocity.y = (_acceleration.y == 0f) ? -0.1f : Mathf.Clamp(
            _velocity.y, -playerStats.MaxFallVelocity,
            playerStats.MaxJumpVelocity);
    }

    private void UpdatePosition()
    {
        _motion = transform.TransformVector(_velocity * Time.fixedDeltaTime);

        _controller.Move(_motion);
    }
}
