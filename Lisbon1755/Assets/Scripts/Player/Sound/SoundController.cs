using UnityEngine;
using System.Collections.Generic;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private SoundTypes soundTypes;

    public SoundTypes GetSetSoundTypes
    {
        get => soundTypes;
        set => soundTypes = value;
    }

    [SerializeField]
    private SoundStats[] soundStats;

    private Dictionary<SoundTypes, GameObject> soundDic;

    private void Start()
    {
        InitializeSounds();
    }

    private void Update()
    {
        SoundSTM();
    }

    private void InitializeSounds()
    {
        soundDic = new Dictionary<SoundTypes, GameObject>();

        soundTypes = SoundTypes.Idle;

        foreach(SoundStats item in soundStats)
        {
            soundDic.Add(item.GetSoundTypes, item.SoundSource);
        }
    }

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
