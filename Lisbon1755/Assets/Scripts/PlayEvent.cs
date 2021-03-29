using UnityEngine;

public class PlayEvent : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private bool isClose;

    public bool IsClose { get => isClose; }

    private void Start()
    {
        isClose = false;
    }

    // enquanto o jogador estiver no evento pode participar
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            isClose = true;
        }
    }

    // se o jogador sair, já não pode participar
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isClose = false;
        }
    }
}
