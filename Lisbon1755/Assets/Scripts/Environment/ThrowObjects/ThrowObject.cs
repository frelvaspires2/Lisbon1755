using UnityEngine;

/// <summary>
/// Spawn an object falling when the player collides with it.
/// </summary>
public class ThrowObject : MonoBehaviour
{
    /// <summary>
    /// Location of the spawner.
    /// </summary>
    [SerializeField]
    private Transform spawnLocation;

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
    /// Check whether the spawner already spawned an object.
    /// </summary>
    private bool isThrowed;

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

    /// <summary>
    /// To be played in the first frame of the game.
    /// </summary>
    private void Start()
    {
        isThrowed = false;
    }

    /// <summary>
    /// Check if the player enters the space.
    /// </summary>
    /// <param name="other"> Collision detection.</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player && !isThrowed)
        {
            isThrowed = true;
            Throw();
        }
    }

    /// <summary>
    /// Throw the object.
    /// </summary>
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
