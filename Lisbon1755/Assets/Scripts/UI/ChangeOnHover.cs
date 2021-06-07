using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOnHover : MonoBehaviour
{
    public Material [] material;
    Renderer rend;

    public Transform sizzle;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        sizzle.GetComponent<ParticleSystem>().enableEmission = false;
    }


    void OnMouseOver()
    {
       rend.sharedMaterial = material[1];
       sizzle.GetComponent<ParticleSystem>().enableEmission = true;
       StartCoroutine(stopSizzles());
    }

    IEnumerator stopSizzles()
    {
        yield return new WaitForSeconds(1f);
        sizzle.GetComponent<ParticleSystem>().enableEmission = false;
    }

    void OnMouseExit()
    {
        rend.sharedMaterial = material[0];
    }
}
