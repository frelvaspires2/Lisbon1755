using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private PlayerStats playerStats;

    [SerializeField]
    private Transform spawn1;

    [SerializeField]
    private Transform spawn2;

    [SerializeField]
    private Transform spawn3;

    private void Update()
    {
        RestoreHealth();
        QuickTravel();
    }

    private void RestoreHealth()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.GetComponent<PlayerHealth>().Health = playerStats.Health;
            player.GetComponent<PlayerHealth>().IsInjured = false;
        }
    }

    private void QuickTravel()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = spawn1.position;
            player.GetComponent<CharacterController>().enabled = true;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = spawn2.position;
            player.GetComponent<CharacterController>().enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = spawn3.position;
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
