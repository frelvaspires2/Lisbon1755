using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCart : MonoBehaviour
{
    [SerializeField]
    private Animator cartAnimator;

    [SerializeField]
    private GameObject player;


    private void Start()
    {
        cartAnimator.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            cartAnimator.enabled = true;
        }
    }
}
