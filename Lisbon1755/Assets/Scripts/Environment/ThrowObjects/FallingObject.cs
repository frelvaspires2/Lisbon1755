using UnityEngine;
using System.Collections;
using URandom = UnityEngine.Random;

/// <summary>
/// Falling object script.
/// </summary>
public class FallingObject : MonoBehaviour
{
    /// <summary>
    /// Set how much damage will give.
    /// </summary>
    [SerializeField]
    private float dmg;

    /// <summary>
    /// Access itself.
    /// </summary>
    [SerializeField]
    private GameObject fallingObject;

    /// <summary>
    /// Access the sound.
    /// </summary>
    [SerializeField]
    private GameObject sound;

    /// <summary>
    /// Checks whether the object has already fallen.
    /// </summary>
    [SerializeField]
    private bool hasFallen;

    /// <summary>
    /// Access the models.
    /// </summary>
    [SerializeField]
    private GameObject[] models;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize variables.
    /// Choose a random model.
    /// </summary>
    private void Start()
    {
        hasFallen = false;
        sound.SetActive(false);
        ChooseModel();
    }

    /// <summary>
    /// Choose a random model.
    /// </summary>
    private void ChooseModel()
    {
        GameObject chosenModel;

        chosenModel = models[URandom.Range(0, models.Length)];

        foreach(GameObject item in models)
        {
            if(item == chosenModel)
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Check if collided with something.
    /// </summary>
    /// <param name="other"> Collision detection.</param>
    private void OnTriggerEnter(Collider other)
    {
        // In case it's the player.
        if(other.gameObject.tag == "Player" && !hasFallen)
        {
            hasFallen = true;
            other.GetComponent<PlayerHealth>().Health -= dmg;
            other.GetComponent<UI_GotHitScreen>().GotHit();
            Destroy(fallingObject);
        }
        // In case it's an NPC.
        if(other.gameObject.tag == "NPC" && !hasFallen)
        {
            hasFallen = true;
            other.GetComponent<PanickedController>().Health -= dmg;
            Destroy(fallingObject);
        }
        // In case it's the floor of the game.
        if(other.gameObject.tag == "Floor" && !hasFallen)
        {
            hasFallen = true;
            sound.SetActive(true);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(DestroyObject());
        }
    }

    /// <summary>
    /// Destroy the object after some time.
    /// </summary>
    /// <returns> Wait for seconds. </returns>
    private IEnumerator DestroyObject()
    {
        WaitForSeconds wfs = new WaitForSeconds(1);

        yield return wfs;

        Destroy(fallingObject);
    }
}
