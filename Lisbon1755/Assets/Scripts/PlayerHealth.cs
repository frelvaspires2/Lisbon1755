using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private PlayerStats playerStats;

    [SerializeField] 
    private float health;
    public float Health { get => health; }

    private void Start()
    {
        health = playerStats.Health;
    }
    private void Update()
    {
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(health < playerStats.Health)
        {
            StartCoroutine(HealingRoutine());
        }
        else
        {
            health = playerStats.Health;
        }
    }

    private IEnumerator HealingRoutine()
    {
        WaitForSeconds wfs = new WaitForSeconds(1);

        if(health < playerStats.Health)
        {
            health += 0.001f;
            yield return wfs;
        }
        StopCoroutine(HealingRoutine());
    }
}
