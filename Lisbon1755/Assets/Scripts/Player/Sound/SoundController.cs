using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Controller of the player's sound.
/// </summary>
public class SoundController : MonoBehaviour
{
    /// <summary>
    /// Access the sound types.
    /// </summary>
    [SerializeField]
    private SoundTypes soundTypes;

    /// <summary>
    /// Gets and sets the sound types.
    /// </summary>
    public SoundTypes GetSetSoundTypes
    {
        get => soundTypes;
        set => soundTypes = value;
    }

    /// <summary>
    /// Access the SoundStats struct.
    /// </summary>
    [SerializeField]
    private SoundStats[] soundStats;

    /// <summary>
    /// Organize all the sounds.
    /// </summary>
    private Dictionary<SoundTypes, GameObject> soundDic;

    /// <summary>
    /// To be played in the first frame.
    /// Initialize the sounds.
    /// </summary>
    private void Start()
    {
        InitializeSounds();
    }

    /// <summary>
    /// To be played in every frame.
    /// Control the sounds.
    /// </summary>
    private void Update()
    {
        SoundSTM();
    }

    /// <summary>
    /// Initialize the sounds.
    /// </summary>
    private void InitializeSounds()
    {
        soundDic = new Dictionary<SoundTypes, GameObject>();

        soundTypes = SoundTypes.Idle;

        foreach(SoundStats item in soundStats)
        {
            soundDic.Add(item.GetSoundTypes, item.SoundSource);
        }
    }

    /// <summary>
    /// Control the sounds.
    /// </summary>
    private void SoundSTM()
    {
        switch(soundTypes)
        {
            case SoundTypes.Idle:
                IdleSound();
                break;

            case SoundTypes.Walk:
                WalkSound();
                break;

            case SoundTypes.Run:
                RunSound();
                break;

            case SoundTypes.Jump:
                JumpSound();
                break;

            case SoundTypes.Roll:
                RollSound();
                break;

            case SoundTypes.InjuredWalk:
                InjuredWalkSound();
                break;

            case SoundTypes.InjuredRun:
                InjuredRunSound();
                break;

            case SoundTypes.Push:
                PushSound();
                break;

            case SoundTypes.KickDoor:
                KickDoorSound();
                break;

            case SoundTypes.Untie:
                UntieSound();
                break;

            case SoundTypes.CallCat:
                CallCatSound();
                break;

            case SoundTypes.WakeUp:
                WakeUpSound();
                break;
        }
    }

    /// <summary>
    /// Play the idle sound.
    /// </summary>
    private void IdleSound()
    {
        foreach (KeyValuePair<SoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == SoundTypes.Idle)
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
    /// Play the walk sound.
    /// </summary>
    private void WalkSound()
    {
        foreach (KeyValuePair<SoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == SoundTypes.Walk)
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
    /// Play the run sound.
    /// </summary>
    private void RunSound()
    {
        foreach (KeyValuePair<SoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == SoundTypes.Run)
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
    /// Play the jump sound.
    /// </summary>
    private void JumpSound()
    {
        foreach (KeyValuePair<SoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == SoundTypes.Jump)
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
    /// Play the roll sound.
    /// </summary>
    private void RollSound()
    {
        foreach (KeyValuePair<SoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == SoundTypes.Roll)
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
    /// Play the walk while injured sound.
    /// </summary>
    private void InjuredWalkSound()
    {
        foreach (KeyValuePair<SoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == SoundTypes.InjuredWalk)
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
    /// Play the run while injured sound.
    /// </summary>
    private void InjuredRunSound()
    {
        foreach (KeyValuePair<SoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == SoundTypes.InjuredRun)
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
    /// Play the push sound.
    /// </summary>
    private void PushSound()
    {
        foreach (KeyValuePair<SoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == SoundTypes.Push)
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
    /// Play the kick door sound.
    /// </summary>
    private void KickDoorSound()
    {
        foreach (KeyValuePair<SoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == SoundTypes.KickDoor)
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
    /// Play the untie sound.
    /// </summary>
    private void UntieSound()
    {
        foreach (KeyValuePair<SoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == SoundTypes.Untie)
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
    /// Play the call cat sound.
    /// </summary>
    private void CallCatSound()
    {
        foreach (KeyValuePair<SoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == SoundTypes.CallCat)
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
    /// Play the wake up sound.
    /// </summary>
    private void WakeUpSound()
    {
        foreach (KeyValuePair<SoundTypes, GameObject> item in soundDic)
        {
            if (item.Key == SoundTypes.WakeUp)
            {
                item.Value.SetActive(true);
            }
            else
            {
                item.Value.SetActive(false);
            }
        }
    }
}
