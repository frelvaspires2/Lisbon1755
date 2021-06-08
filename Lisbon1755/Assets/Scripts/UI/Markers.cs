using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// Setup the markers.
/// </summary>
[Serializable]
public class Markers
{
    /// <summary>
    /// Access the marker's image.
    /// </summary>
    [SerializeField]
    private Image img;

    /// <summary>
    /// Gets or sets the marker's image.
    /// </summary>
    public Image GetSetImg
    {
        get => img;
        set => img = value;
    }

    /// <summary>
    /// Access the transform of the target.
    /// </summary>
    [SerializeField]
    private Transform target;

    /// <summary>
    /// Gets or sets the transform of the target.
    /// </summary>
    public Transform GetSetTarget
    {
        get => target;
        set => target = value;
    }

    /// <summary>
    /// Access the text of target's distance.
    /// </summary>
    [SerializeField]
    private Text meter;

    /// <summary>
    /// Gets or set the text of the target's distance.
    /// </summary>
    public Text GetSetMeter
    {
        get => meter;
        set => meter = value;
    }

    /// <summary>
    /// Access the offset vector 3.
    /// </summary>
    [SerializeField]
    private Vector3 offset;

    /// <summary>
    /// Gets or sets the offest vector 3.
    /// </summary>
    public Vector3 GetSetOffset
    {
        get => offset;
        set => offset = value;
    }
}
