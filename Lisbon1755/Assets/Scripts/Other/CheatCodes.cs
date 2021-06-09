using UnityEngine;

/// <summary>
/// Cheat codes for game testing purposes.
/// </summary>
public class CheatCodes : MonoBehaviour
{
    /// <summary>
    /// The player's gameobject.
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// Access the player stats scriptableobject.
    /// </summary>
    [SerializeField]
    private PlayerStats playerStats;

    /// <summary>
    /// Access the spawn1 location.
    /// </summary>
    [SerializeField]
    private Transform spawn1;

    /// <summary>
    /// Access the spawn2 location.
    /// </summary>
    [SerializeField]
    private Transform spawn2;

    /// <summary>
    /// Access the spawn3 location.
    /// </summary>
    [SerializeField]
    private Transform spawn3;

    /// <summary>
    /// To be played in every frame.
    /// Run the restore health and quick travel cheat.
    /// </summary>
    private void Update()
    {
        RestoreHealth();
        QuickTravel();
    }

    /// <summary>
    /// Restore health cheat.
    /// </summary>
    private void RestoreHealth()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.GetComponent<PlayerHealth>().Health = playerStats.Health;
            player.GetComponent<PlayerHealth>().IsInjured = false;
        }
    }

    /// <summary>
    /// Quick travel cheat.
    /// </summary>
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
