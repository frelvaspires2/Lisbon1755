using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Animation controller.
/// </summary>
public class PlayerAnimController : MonoBehaviour
{
    /// <summary>
    /// Access the PlayerMovement script.
    /// </summary>
    [SerializeField]
    private PlayerMovement playerMovement;

    /// <summary>
    /// Access the animations in SetAnimation struct.
    /// </summary>
    [SerializeField]
    private SetAnimations[] setAnimation;

    /// <summary>
    /// Organize the animations.
    /// </summary>
    private Dictionary<PlayerAnimTypes, GameObject> animationDic;

    /// <summary>
    /// Access the PlayerAnimTypes enum.
    /// </summary>
    [SerializeField]
    private PlayerAnimTypes playerAnimTypes;

    /// <summary>
    /// Gets and sets the PlayerAnimTypes
    /// </summary>
    public PlayerAnimTypes GetSetPlayerAnimTypes { 
        get => playerAnimTypes; 
        set => playerAnimTypes = value; 
    }

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize variables.
    /// Puts the animations in the dictionary.
    /// </summary>
    private void Start()
    {
        animationDic = new Dictionary<PlayerAnimTypes, GameObject>();

        foreach(SetAnimations item in setAnimation)
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
        switch (playerAnimTypes)
        {
            case PlayerAnimTypes.idle:
                IdleAnim();
                break;
            case PlayerAnimTypes.walk:
                WalkAnim();
                break;
            case PlayerAnimTypes.run:
                RunAnim();
                break;
            case PlayerAnimTypes.jump:
                JumpAnim();
                break;
            case PlayerAnimTypes.roll:
                RollAnim();
                break;
            case PlayerAnimTypes.back:
                BackAnim();
                break;
            case PlayerAnimTypes.runBack:
                RunBackAnim();
                break;
            case PlayerAnimTypes.rightStrade:
                RightStradeAnim();
                break;
            case PlayerAnimTypes.leftStrade:
                LeftStradeAnim();
                break;
            case PlayerAnimTypes.rightStradeRun:
                RightStradeRunAnim();
                break;
            case PlayerAnimTypes.leftStradeRun:
                LeftStradeRunAnim();
                break;
            case PlayerAnimTypes.injuredRunBack:
                InjuredRunBackAnim();
                break;
            case PlayerAnimTypes.InjuredRun:
                InjuredRunAnim();
                break;
            case PlayerAnimTypes.InjuredWalkBack:
                InjuredWalkBackAnim();
                break;
            case PlayerAnimTypes.InjuredWalk:
                InjuredWalk();
                break;
            case PlayerAnimTypes.Push:
                PushAnim();
                break;
            case PlayerAnimTypes.KickDoor:
                KickDoorAnim();
                break;
            case PlayerAnimTypes.Untie:
                UntieAnim();
                break;
            case PlayerAnimTypes.CallCat:
                CallCatAnim();
                break;
            case PlayerAnimTypes.WakeUpNPC:
                WakeUpNPCAnim();
                break;
            case PlayerAnimTypes.HelpNPC:
                HelpNPCAnim();
                break;
        }
    }

    /// <summary>
    /// Run the idle animation.
    /// </summary>
    private void IdleAnim()
    {
        foreach(KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if(item.Key == PlayerAnimTypes.idle)
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
    /// Run the walk animation.
    /// </summary>
    private void WalkAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.walk)
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
    /// Run the run animation.
    /// </summary>
    private void RunAnim()
    {

        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.run)
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
    /// Run the jump animation.
    /// </summary>
    private void JumpAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.jump)
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
    /// Run the roll animation.
    /// </summary>
    private void RollAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.roll)
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
    /// Run the walking backward animation.
    /// </summary>
    private void BackAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.back)
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
    /// Run the running backward animation.
    /// </summary>
    private void RunBackAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.runBack)
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
    /// Run the right strade walk animation.
    /// </summary>
    private void RightStradeAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.rightStrade)
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
    /// Run the left strade walk animation.
    /// </summary>
    private void LeftStradeAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.leftStrade)
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
    /// Run the right strade run animation.
    /// </summary>
    private void RightStradeRunAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.rightStradeRun)
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
    /// Run the left strade run animation.
    /// </summary>
    private void LeftStradeRunAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.leftStradeRun)
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
    /// Run the running backwards animation while injured.
    /// </summary>
    private void InjuredRunBackAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.injuredRunBack)
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
    /// Run the running animation while injured.
    /// </summary>
    private void InjuredRunAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.InjuredRun)
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
    /// Run the walking backwards animation while injured.
    /// </summary>
    private void InjuredWalkBackAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.InjuredWalkBack)
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
    /// Run the walking animation while injured.
    /// </summary>
    private void InjuredWalk()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.InjuredWalk)
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
    /// Run the Push animation in the event of Person Stuck in Objects.
    /// </summary>
    private void PushAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.Push)
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
    /// Run the Kick animation in the event of Person Stuck in House.
    /// </summary>
    private void KickDoorAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.KickDoor)
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
    /// Run the Untie animation in the event of the Heretics.
    /// </summary>
    private void UntieAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.Untie)
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
    /// Run the Call Cat animation in the event of Cat in Distress.
    /// </summary>
    private void CallCatAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.CallCat)
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
    /// Run the Wake Up animation in the event of Wake Up NPC.
    /// </summary>
    private void WakeUpNPCAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.WakeUpNPC)
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
    /// Run the Help animation in the event of Wake Up NPC.
    /// </summary>
    private void HelpNPCAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in 
            animationDic)
        {
            if (item.Key == PlayerAnimTypes.HelpNPC)
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
