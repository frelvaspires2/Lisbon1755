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

        foreach(SoundStats item in soundStats)
        {
            soundDic.Add(item.GetSoundTypes, item.SoundSource);
        }
    }

    private void SoundSTM()
    {
        switch(soundTypes)
        {
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
}
