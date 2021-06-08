using UnityEngine;

/// <summary>
/// Give damage to the selected agent.
/// </summary>
public class WoundAgent : MonoBehaviour
{
    /// <summary>
    /// Access the agent.
    /// </summary>
    [SerializeField]
    private WoundAgentStats[] selectedAgent;

    /// <summary>
    /// Set the damage points to be given.
    /// </summary>
    [SerializeField]
    private float dmg;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Set the selected agent/s IsDMG bool to false.
    /// </summary>
    private void Start()
    {
        for(int i = 0; i < selectedAgent.Length; i++)
        {
            selectedAgent[i].IsDMG = false;
        }
    }

    /// <summary>
    /// To be played in every frame of the game.
    /// Give damage to the selected agent/s.
    /// </summary>
    private void Update()
    {
        GiveDamage();
    }

    /// <summary>
    /// Check whether the selected agent is active.
    /// </summary>
    /// <param name="agent"> The selected agent.</param>
    /// <returns> True if he's active and false if not.</returns>
    private bool CheckIfActive(GameObject agent)
    {
        if (agent != null)
        {
            if (agent.activeSelf)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Give damage to the agent/s.
    /// </summary>
    private void GiveDamage()
    {
        for (int i = 0; i < selectedAgent.Length; i++)
        {
            if (CheckIfActive(selectedAgent[i].SelectedAgent))
            {
                if (!selectedAgent[i].IsDMG)
                {
                    selectedAgent[i].SelectedAgent
                        .GetComponent<PanickedController>().Health -= dmg;
                    selectedAgent[i].IsDMG = true;
                }
            }
        }
    }
}
