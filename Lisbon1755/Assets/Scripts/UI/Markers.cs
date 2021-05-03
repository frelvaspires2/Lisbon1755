using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class Markers
{
    [SerializeField]
    private Image img;

    public Image GetSetImg
    {
        get => img;
        set => img = value;
    }

    [SerializeField]
    private Transform target;

    public Transform GetSetTarget
    {
        get => target;
        set => target = value;
    }

    [SerializeField]
    private Text meter;

    public Text GetSetMeter
    {
        get => meter;
        set => meter = value;
    }

    [SerializeField]
    private Vector3 offset;

    public Vector3 GetSetOffset
    {
        get => offset;
        set => offset = value;
    }
}
