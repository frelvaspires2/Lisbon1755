using UnityEngine;
using System.Collections.Generic;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private SetAnimations[] setAnimation;

    private Dictionary<PlayerAnimTypes, GameObject> animationDic;

    private void Start()
    {
        animationDic = new Dictionary<PlayerAnimTypes, GameObject>();

        foreach(SetAnimations item in setAnimation)
        {
            animationDic.Add(item.AnimationTypes, item.Animation);
        }
    }

    private void Update()
    {
        AnimSTM();
    }

    private void AnimSTM()
    {
        switch (playerMovement.GetPlayerAnimTypes)
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
            case PlayerAnimTypes.rightstrade:
                RightStradeAnim();
                break;
            case PlayerAnimTypes.leftstrade:
                LeftStradeAnim();
                break;
            case PlayerAnimTypes.rightstraderun:
                RightStradeRunAnim();
                break;
            case PlayerAnimTypes.leftstraderun:
                LeftStradeRunAnim();
                break;
        }
    }

    private void IdleAnim()
    {
        foreach(KeyValuePair<PlayerAnimTypes, GameObject> item in animationDic)
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

    private void WalkAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in animationDic)
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

    private void RunAnim()
    {

        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in animationDic)
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

    private void JumpAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in animationDic)
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

    private void RollAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in animationDic)
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

    private void BackAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in animationDic)
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

    private void RunBackAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in animationDic)
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

    private void RightStradeAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in animationDic)
        {
            if (item.Key == PlayerAnimTypes.rightstrade)
            {
                item.Value.SetActive(true);
            }
            else
            {
                item.Value.SetActive(false);
            }
        }
    }

    private void LeftStradeAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in animationDic)
        {
            if (item.Key == PlayerAnimTypes.leftstrade)
            {
                item.Value.SetActive(true);
            }
            else
            {
                item.Value.SetActive(false);
            }
        }
    }

    private void RightStradeRunAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in animationDic)
        {
            if (item.Key == PlayerAnimTypes.rightstraderun)
            {
                item.Value.SetActive(true);
            }
            else
            {
                item.Value.SetActive(false);
            }
        }
    }

    private void LeftStradeRunAnim()
    {
        foreach (KeyValuePair<PlayerAnimTypes, GameObject> item in animationDic)
        {
            if (item.Key == PlayerAnimTypes.leftstraderun)
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
