using System.Collections.Generic;
using System.Collections;
using UnityEngine;

/// <summary>
/// Sound controller of the panicked person.
/// </summary>
public class AISoundController : MonoBehaviour
{
    /// <summary>
    /// Access the sound types.
    /// </summary>
    [SerializeField]
    private AISoundTypes aiSoundTypes;

    /// <summary>
    /// Gets the sound types.
    /// </summary>
    public AISoundTypes GetSetAISoundTypes
    {
        get => aiSoundTypes;
        set => aiSoundTypes = value;
    }

    /// <summary>
    /// Access the sound stats of each sound.
    /// </summary>
    [SerializeField]
    private AISoundStats[] aiSoundStats;

    /// <summary>
    /// Sound dictionary.
    /// </summary>
    private Dictionary<AISoundTypes, GameObject> soundDic;


    /// <summary>
    /// Access the got hit sound gameobject.
    /// </summary>
    [SerializeField]
    private GameObject gotHitSound;

    /// <summary>
    /// Got hit sound time.
    /// To be set by the game designer in inspector.
    /// </summary>
    [SerializeField]
    private float hitSoundTime = 1f;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize the sounds.
    /// </summary>
    private void Awake()
    {
        InitializeSounds();
    }

    /// <summary>
    /// To be played in every frame of the game.
    /// Control the sound.
    /// </summary>
    private void Update()
    {
        SoundController();
    }

    /// <summary>
    /// Initialize the sounds into the dictionary.
    /// </summary>
    private void InitializeSounds()
    {
        aiSoundTypes = AISoundTypes.Running;

        soundDic = new Dictionary<AISoundTypes, GameObject>();

        for(int i = 0; i < aiSoundStats.Length; i++)
        {
            soundDic.Add(aiSoundStats[i].GetAISoundType, aiSoundStats[i].Sound);
        }

        gotHitSound.SetActive(false);
    }

    /// <summary>
    /// Control the sounds.
    /// </summary>
    private void SoundController()
    {
        switch(aiSoundTypes)
        {
            case AISoundTypes.Running:
                RunningSound();
                break;

            case AISoundTypes.RunningSlow:
                RunningSlowSound();
                break;

            case AISoundTypes.Dying:
                DyingSound();
                break;

            case AISoundTypes.Wounded:
                WoundedSound();
                break;
        }
    }

    /// <summary>
    /// Play the running sound.
    /// </summary>
    private void RunningSound()
    {
        foreach (KeyValuePair<AISoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == AISoundTypes.Running)
            {
                item.Value.SetActive(true);
            }
            else
            {
                item.Value.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Play the running slow sound.
    /// </summary>
    private void RunningSlowSound()
    {
        foreach (KeyValuePair<AISoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == AISoundTypes.RunningSlow)
            {
                item.Value.SetActive(true);
            }
            else
            {
                item.Value.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Play the wounded sound.
    /// </summary>
    private void WoundedSound()
    {
        foreach (KeyValuePair<AISoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == AISoundTypes.Wounded)
            {
                item.Value.SetActive(true);
            }
            else
            {
                item.Value.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Play the dying sound.
    /// </summary>
    private void DyingSound()
    {
        foreach (KeyValuePair<AISoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == AISoundTypes.Dying)
            {
                item.Value.SetActive(true);
            }
            else
            {
                item.Value.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Play the got hit sound.
    /// </summary>
    public void GotHitSound()
    {
        StartCoroutine(HitRoutine());
    }

    /// <summary>
    /// Got hit sound routine.
    /// </summary>
    /// <returns> Wait for seconds.</returns>
    private IEnumerator HitRoutine()
    {
        WaitForSeconds wfs = new WaitForSeconds(hitSoundTime);

        gotHitSound.SetActive(true);

        yield return wfs;

        gotHitSound.SetActive(false);
    }
}
