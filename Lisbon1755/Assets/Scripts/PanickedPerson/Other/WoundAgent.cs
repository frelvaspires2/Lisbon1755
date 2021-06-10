using UnityEngine;

public class WoundAgent : MonoBehaviour
{
    /// <summary>
    /// Check if something entered on the trigger.
    /// </summary>
    /// <param name="other"> Collider</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            other.GetComponent<PanickedController>().Health = 10;
            Destroy(this.gameObject);
        }
    }
}
