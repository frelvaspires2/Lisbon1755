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

    private Vector3 spawn;

    private bool isThrowed;

    [SerializeField]
    private float speed = 4;

    [SerializeField]
    private float directionY;

    [SerializeField]
    private bool addForce;

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

        Rigidbody rb = Instantiate(fallingObject.GetComponent<Rigidbody>(),
            new Vector3(spawnLocation.position.x, spawnLocation.position.y,
            spawnLocation.position.z), Quaternion.identity);

        if (addForce)
        {
            transform.Rotate(new Vector3(0, directionY, 0), Space.World);
            rb.velocity = transform.forward * speed;
        }
    }
}
