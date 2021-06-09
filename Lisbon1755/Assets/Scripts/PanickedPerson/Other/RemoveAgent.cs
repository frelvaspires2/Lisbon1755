using UnityEngine;

/// <summary>
/// Remove the agent the he reaches his goal.
/// </summary>
public class RemoveAgent : MonoBehaviour
{
    /// <summary>
    /// Access the trigger gameobject.
    /// </summary>
    [SerializeField]
    private GameObject trigger;

    /// <summary>
    /// Detect if the agent entered the object.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == trigger)
        {
            Destroy(gameObject);
        }
    }
}
