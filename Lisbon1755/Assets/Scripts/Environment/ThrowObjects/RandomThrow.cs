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
    /// Setup the spawners.
    /// </summary>
    [SerializeField]
    private SpawnerStats[] spawners;

    /// <summary>
    /// Location of the spawners.
    /// </summary>
    private Dictionary<int, SpawnerStats> spawnLocations;

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
    /// Set the time of spawn.
    /// </summary>
    [SerializeField]
    private float time;

    /// <summary>
    /// Checks whether the spawner already spawned.
    /// </summary>
    private bool isSpawned;


    private void Start()
    {
        isSpawned = false;
        SetUpSpawners();
    }

    private void SetUpSpawners()
    {
        spawnLocations = new Dictionary<int, SpawnerStats>();

        for(int i = 0; i < spawners.Length; i++)
        {
            spawnLocations.Add(i, spawners[i]);
        }
    }

    private void Update()
    {
        Spawners();
    }

    /// <summary>
    /// Throw the object.
    /// </summary>
    private void Throw(int key)
    {
        Rigidbody rb = Instantiate(fallingObject.GetComponent<Rigidbody>(),
            new Vector3(spawnLocations[key].Position.position.x,
            spawnLocations[key].Position.position.y,
            spawnLocations[key].Position.position.z), Quaternion.identity);

        if (spawnLocations[key].AddForce)
        {
            transform.Rotate(new Vector3(0, spawnLocations[key].DirectionY, 0),
                Space.World);
            rb.velocity = transform.forward * spawnLocations[key].Speed;
        }

        transform.Rotate(new Vector3(0, -spawnLocations[key].DirectionY, 0),
               Space.World);
    }

    private void Spawners()
    {
        SRandom rnd = new SRandom();

        int selectedSpawner;

        if (!isSpawned)
        {
            selectedSpawner = rnd.Next(0, spawnLocations.Count);
            Throw(selectedSpawner);
            Debug.Log("Selected spawner: " + selectedSpawner);
            isSpawned = true;
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        WaitForSeconds wfs = new WaitForSeconds(time);

        yield return wfs;

        isSpawned = false;

        StopCoroutine(Wait());
    }
}
