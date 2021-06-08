using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoundAgent : MonoBehaviour
{
    [SerializeField]
    private WoundAgentStats[] selectedAgent;

    [SerializeField]
    private float dmg;

    private void Start()
    {
        for(int i = 0; i < selectedAgent.Length; i++)
        {
            selectedAgent[i].IsDMG = false;
        }
    }

    private void Update()
    {
        GiveDamage();
    }

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

    private void GiveDamage()
    {
        for (int i = 0; i < selectedAgent.Length; i++)
        {
            if (CheckIfActive(selectedAgent[i].SelectedAgent))
            {
                if (!selectedAgent[i].IsDMG)
                {
                    selectedAgent[i].SelectedAgent.GetComponent<PanickedController>().Health -= dmg;
                    selectedAgent[i].IsDMG = true;
                }
            }
        }
    }
}
