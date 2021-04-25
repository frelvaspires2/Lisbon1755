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
    private Dictionary<int, SpawnerStats> spawnDic;

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
    /// Set the time of spawn.
    /// </summary>
    [SerializeField]
    private float time;

    /// <summary>
    /// Checks whether the spawner already spawned.
    /// </summary>
    private bool isSpawned;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Setup variables and the spawners.
    /// </summary>
    private void Start()
    {
        isSpawned = false;
        SetUpSpawners();
    }

    /// <summary>
    /// Set up the spawners.
    /// </summary>
    private void SetUpSpawners()
    {
        spawnDic = new Dictionary<int, SpawnerStats>();

        for(int i = 0; i < spawners.Length; i++)
        {
            spawnDic.Add(i, spawners[i]);
        }
    }

    /// <summary>
    /// To be played in every frame.
    /// </summary>
    private void Update()
    {
        Spawn();
    }

    /// <summary>
    /// Throw the object.
    /// </summary>
    private void Throw(int key)
    {
        Rigidbody rb = Instantiate(fallingObject.GetComponent<Rigidbody>(),
            new Vector3(spawnDic[key].Position.position.x,
            spawnDic[key].Position.position.y,
            spawnDic[key].Position.position.z), Quaternion.identity);

        if (spawnDic[key].AddForce)
        {
            transform.Rotate(new Vector3(0, spawnDic[key].DirectionY, 0),
                Space.World);
            rb.velocity = transform.forward * spawnDic[key].Speed;

            transform.Rotate(new Vector3(0, -spawnDic[key].DirectionY, 0),
              Space.World);
        }
    }

    /// <summary>
    /// Select a spawner and spawn.
    /// </summary>
    private void Spawn()
    {
        SRandom rnd = new SRandom();

        int selectedSpawner;

        if (!isSpawned)
        {
            selectedSpawner = rnd.Next(0, spawnDic.Count);
            Throw(selectedSpawner);
            isSpawned = true;
            StartCoroutine(Wait());
        }
    }

    /// <summary>
    /// Wait some time between spawns.
    /// </summary>
    /// <returns> Wait for seconds.</returns>
    private IEnumerator Wait()
    {
        WaitForSeconds wfs = new WaitForSeconds(time);

        yield return wfs;

        isSpawned = false;

        StopCoroutine(Wait());
    }
}
