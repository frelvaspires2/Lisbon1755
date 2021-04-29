using UnityEngine;

public class TriggerPanick : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject spawn;

    private bool isSpawn;

    private void Start()
    {
        isSpawn = false;
        spawn.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            if(!isSpawn)
            {
                spawn.SetActive(true);
                isSpawn = true;
            }
        }
    }
}
