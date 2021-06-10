using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStats : MonoBehaviour
{
    /// <summary>
    /// Check if something entered on the trigger.
    /// </summary>
    /// <param name="other"> Collider</param>
    private void OnTriggerEnter(Collider other)
    {
        // If it's an NPC, then decrement health.
        if (other.gameObject.tag == "NPC")
        {
            other.GetComponent<PanickedController>().Health = 10;
            Destroy(this.gameObject);
        }
    }
}
