using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control the animations for panick person agent.
/// </summary>
public class PanickAnimController : MonoBehaviour
{
    [SerializeField]
    private GameObject idle;

    /// <summary>
    /// Access the animations in SetPanickAnimation struct.
    /// </summary>
    [SerializeField]
    private SetPanicAnimations[] setAnimation;

    /// <summary>
    /// Organize the animations.
    /// </summary>
    private Dictionary<PanickAnimTypes, GameObject> animationDic;

    /// <summary>
    /// Access the PlayerAnimTypes enum.
    /// </summary>
    [SerializeField]
    private PanickAnimTypes panickAnimTypes;

    /// <summary>
    /// Gets and sets the PlayerAnimTypes
    /// </summary>
    public PanickAnimTypes GetSetPanickAnimTypes
    {
        get => panickAnimTypes;
        set => panickAnimTypes = value;
    }

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize variables.
    /// Puts the animations in the dictionary.
    /// </summary>
    private void Start()
    {
        idle.SetActive(false);

        animationDic = new Dictionary<PanickAnimTypes, GameObject>();

        foreach (SetPanicAnimations item in setAnimation)
        {
            animationDic.Add(item.AnimationType, item.Animation);
        }
    }

    /// <summary>
    /// To be played in every frame.
    /// </summary>
    private void Update()
    {
        AnimSTM();
    }

    /// <summary>
    /// Control the animations.
    /// </summary>
    private void AnimSTM()
    {
        switch(panickAnimTypes)
        {
            case PanickAnimTypes.Running:
                RunningAnim();
                break;
            case PanickAnimTypes.RunningSlower:
                RunningSlowerAnim();
                break;
            case PanickAnimTypes.Wounded:
                WoundedAnim();
                break;
            case PanickAnimTypes.Dying:
                DyingAnim();
                break;
        }
    }

    /// <summary>
    /// Play the running animation.
    /// </summary>
    private void RunningAnim()
    {
        foreach (KeyValuePair<PanickAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PanickAnimTypes.Running)
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
    /// Play the running slower animation.
    /// </summary>
    private void RunningSlowerAnim()
    {
        foreach (KeyValuePair<PanickAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PanickAnimTypes.RunningSlower)
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
    /// Play the wounded animation.
    /// </summary>
    private void WoundedAnim()
    {
        foreach (KeyValuePair<PanickAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PanickAnimTypes.Wounded)
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
    /// Play the dying animation.
    /// </summary>
    private void DyingAnim()
    {
        foreach (KeyValuePair<PanickAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PanickAnimTypes.Dying)
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
