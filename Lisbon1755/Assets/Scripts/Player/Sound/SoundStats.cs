using UnityEngine;
using System;

[Serializable]
public struct SoundStats 
{
    [SerializeField]
    private GameObject soundSource;

    public GameObject SoundSource { get => soundSource; }


    [SerializeField]
    private SoundTypes soundTypes;

    public SoundTypes GetSoundTypes { get => soundTypes; }
}
