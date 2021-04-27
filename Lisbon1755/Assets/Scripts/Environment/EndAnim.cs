using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnim : MonoBehaviour
{
    [SerializeField]
    private CameraShake cameraShake;

    [SerializeField]
    private bool isAnimationFinished;

    public bool IsAnimationFinished { get => isAnimationFinished; }

    [SerializeField]
    private GameObject dmgZone;

    [SerializeField]
    private GameObject blockZone;


    private void Start()
    {
        isAnimationFinished = false;
        dmgZone.SetActive(false);
        blockZone.SetActive(false);
    }

    public void StopAnim()
    {
        //cameraShake.CanShake = false;
        isAnimationFinished = true;
        dmgZone.SetActive(true);
        StartCoroutine(StopDMG());
    }

    private IEnumerator StopDMG()
    {
        WaitForSeconds wfs = new WaitForSeconds(1);

        yield return wfs;

        Destroy(dmgZone);

        blockZone.SetActive(true);
    }
}
