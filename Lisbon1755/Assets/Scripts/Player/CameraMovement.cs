using UnityEngine;

/// <summary>
/// Camera movement.
/// </summary>
public class CameraMovement : MonoBehaviour
{
    /// <summary>
    /// Access the camera.
    /// </summary>
    private Camera camera;

    /// <summary>
    /// Access the player stats scriptableobject.
    /// </summary>
    [SerializeField]
    private PlayerStats playerStats;

    /// <summary>
    /// New rotation.
    /// </summary>
    private Vector3     newRotation;

    /// <summary>
    /// New position.
    /// </summary>
    private Vector3     newPosition;

    /// <summary>
    /// Intended position.
    /// </summary>
    private Vector3     intendedPosition;

    /// <summary>
    /// Translation acceleration.
    /// </summary>
    private float       translationAcceleration;

    /// <summary>
    /// Translation velocity.
    /// </summary>
    private float       translationVelocity;

    /// <summary>
    /// Raycast hit information.
    /// </summary>
    private RaycastHit  raycastHitInfo;

    /// <summary>
    /// To be played in the first frame.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        camera = GetComponentInChildren<Camera>();

        intendedPosition           = camera.transform.localPosition;
        translationAcceleration    = 0f;
        translationVelocity        = 0f;
    }

    /// <summary>
    /// To be played every frame.
    /// </summary>
    private void Update()
    {
        UpdateCameraRotation();
        UpdateCameraPosition();
        PreventCharacterOcclusion();
    }

    /// <summary>
    /// Update the camera's rotation.
    /// </summary>
    private void UpdateCameraRotation()
    {
        newRotation = transform.localEulerAngles;

        transform.localEulerAngles = newRotation;
    }

    /// <summary>
    /// Update the camera's position.
    /// </summary>
    private void UpdateCameraPosition()
    {
        if (translationAcceleration != 0f)
            translationVelocity = Mathf.Clamp(translationVelocity + translationAcceleration * Time.deltaTime,
                -playerStats.MaxTranslationVelocity, playerStats.MaxTranslationVelocity);
        else if (translationVelocity > 0)
            translationVelocity = Mathf.Max(translationVelocity - playerStats.TransLationDeceleration * Time.deltaTime, 0f);
        else
            translationVelocity = Mathf.Min(translationVelocity + playerStats.TransLationDeceleration * Time.deltaTime, 0f);

        newPosition = camera.transform.localPosition;
        newPosition.z = Mathf.Clamp(newPosition.z + translationVelocity * Time.deltaTime,
            -playerStats.MaxDistance, -playerStats.MinDistance);

        camera.transform.localPosition = newPosition;

        if (translationVelocity != 0f)
            intendedPosition = newPosition;
    }

    /// <summary>
    /// Prevent character occlusion.
    /// </summary>
    private void PreventCharacterOcclusion()
    {
        if (Physics.Linecast(transform.position, camera.transform.TransformPoint(intendedPosition), out raycastHitInfo))
            camera.transform.position = Vector3.Lerp(camera.transform.position, raycastHitInfo.point, playerStats.AutoAdjustSpeed * Time.deltaTime);
        else
            camera.transform.localPosition = Vector3.Lerp(camera.transform.localPosition, intendedPosition, playerStats.AutoAdjustSpeed * Time.deltaTime);
    }
}
