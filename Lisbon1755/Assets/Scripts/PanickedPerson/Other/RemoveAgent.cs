using UnityEngine;

public class RemoveAgent : MonoBehaviour
{
    [SerializeField]
    private GameObject trigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == trigger)
        {
            Destroy(gameObject);
        }
    }
}
