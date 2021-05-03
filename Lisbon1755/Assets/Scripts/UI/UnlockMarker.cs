using UnityEngine;

public class UnlockMarker : MonoBehaviour
{
    [SerializeField]
    private GameObject[] marker;

    [SerializeField]
    private GameObject player;

    private bool isActivated;

    private void Start()
    {
        foreach (GameObject item in marker)
        {
            item.SetActive(false);
        }

        isActivated = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player && !isActivated)
        {
            foreach(GameObject item in marker)
            {
                item.SetActive(true);
            }

            isActivated = true;
        }
    }
}
