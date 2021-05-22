using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHelp : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private PanickedController panickedController;

    [SerializeField]
    private PanickedStats panickedStats;

    [SerializeField]
    private Transform setPosition;

    [SerializeField]
    private bool isWounded;

    [SerializeField]
    private bool isInside;

    [SerializeField]
    private float setClicks;

    [SerializeField]
    private float clickCount;

    private void Start()
    {
        isInside = false;
        isWounded = false;
        clickCount = 0;
    }

    private void Update()
    {
        CheckState();
        Help();
    }

    private void CheckState()
    {
        if(panickedController.GetStates == PanickedState.WoundedInTheGround)
        {
            isWounded = true;
        }
        else
        {
            isWounded = false;
            isInside = false;
            clickCount = 0;
        }
    }

    private void Help()
    {
        if(isInside)
        {
            if(Input.GetButton("MouseClick"))
            {
                //Debug.Log("Helping NPC");
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = setPosition.position;
                player.transform.rotation = setPosition.rotation;
                player.GetComponent<CharacterController>().enabled = true;

                //panickedController.Health += 1 * Time.deltaTime;

                if(clickCount < setClicks)
                {
                    clickCount += 1 * Time.deltaTime;
                }

                if(clickCount >= setClicks)
                {
                    panickedController.Health = panickedStats.Health / 1.5f;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player && isWounded)
        {
            isInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player && isWounded)
        {
            isInside = false;
        }
    }
}
