using System;
using UnityEngine;

[Serializable]
public struct SetAnimations 
{
    [SerializeField]
    private PlayerAnimTypes animationTypes;

    public PlayerAnimTypes AnimationTypes { get => animationTypes; }

    [SerializeField]
    private GameObject animations;

    public GameObject Animation { get => animations; }
}
