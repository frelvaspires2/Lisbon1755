using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCart : MonoBehaviour
{
    [SerializeField]
    private GameObject cartMarker;

    [SerializeField]
    private Animator cartAnimator;

    [SerializeField]
    private GameObject player;


    private void Start()
    {
        cartAnimator.enabled = false;
        cartMarker.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            cartMarker.SetActive(true);
            cartAnimator.enabled = true;
        }
    }
}
