using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [SerializeField]
    private Transform spawnLocation;

    [SerializeField]
    private GameObject fallingObject;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Vector3 spawn;

    [SerializeField]
    private bool isThrowed;

    private void Start()
    {
        isThrowed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player && !isThrowed)
        {
            isThrowed = true;
            Throw();
        }
    }

    private void Throw()
    {
        spawn = spawnLocation.position;

        Instantiate(fallingObject, 
            new Vector3(spawnLocation.position.x, spawnLocation.position.y, 
            spawnLocation.position.z), Quaternion.identity);
    }
}
