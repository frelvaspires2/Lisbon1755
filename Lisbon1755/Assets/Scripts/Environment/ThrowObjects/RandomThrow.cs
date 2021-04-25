using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using SRandom = System.Random;

/// <summary>
/// Spawn an object falling when the player collides with it.
/// </summary>
public class RandomThrow : MonoBehaviour
{
    /// <summary>
    /// Location of the spawner.
    /// </summary>
    [SerializeField]
    private List<Transform> spawnLocations;

    /// <summary>
    /// Falling object prefab.
    /// </summary>
    [SerializeField]
    private GameObject fallingObject;

    /// <summary>
    /// Access the player gameobject.
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// Vector 3 of the spawner.
    /// </summary>
    private Vector3 spawn;

    /// <summary>
    /// Set the speed if force is going to be added.
    /// </summary>
    [SerializeField]
    private float speed = 4;

    /// <summary>
    /// Set the direction (y) which the spawner will spawn the object.
    /// </summary>
    [SerializeField]
    private float directionY;

    /// <summary>
    /// Checks whether the game designer is going to add force.
    /// </summary>
    [SerializeField]
    private bool addForce;

    [SerializeField]
    private float time;


    private bool isSpawned;


    private void Start()
    {
        isSpawned = false;
    }

    private void Update()
    {
        Spawners();
    }

    /// <summary>
    /// Throw the object.
    /// </summary>
    private void Throw(Transform spawnLocation)
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

    private void Spawners()
    {
        SRandom rnd = new SRandom();

        Transform selectedSpawner;

        if (!isSpawned)
        {
            selectedSpawner = spawnLocations[rnd.Next(0, spawnLocations.Count)];
            Throw(selectedSpawner);
            isSpawned = true;
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        WaitForSeconds wfs = new WaitForSeconds(time);

        yield return wfs;

        isSpawned = false;
    }
}
