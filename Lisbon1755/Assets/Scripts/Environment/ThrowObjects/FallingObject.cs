using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField]
    private float dmg;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().Health -= dmg;
        }
        if(other.gameObject.tag == "NPC")
        {
            other.GetComponent<PanickedController>().Health -= dmg;
        }
    }
}
