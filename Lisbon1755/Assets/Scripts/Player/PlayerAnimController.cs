using UnityEngine;
using System.Collections.Generic;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private List<GameObject> animationList = new List<GameObject>();

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
        for(int i = 0; i < animationList.Count; i++)
        {
            if(i == 0)
            {
                animationList[i].SetActive(true);
            }
            else
            {
                animationList[i].SetActive(false);
            }
        }
    }

    private void WalkAnim()
    {
        for (int i = 0; i < animationList.Count; i++)
        {
            if (i == 1)
            {
                animationList[i].SetActive(true);
            }
            else
            {
                animationList[i].SetActive(false);
            }
        }
    }

    private void RunAnim()
    {

        for (int i = 0; i < animationList.Count; i++)
        {
            if (i == 2)
            {
                animationList[i].SetActive(true);
            }
            else
            {
                animationList[i].SetActive(false);
            }
        }
    }

    private void JumpAnim()
    {
        for (int i = 0; i < animationList.Count; i++)
        {
            if (i == 3)
            {
                animationList[i].SetActive(true);
            }
            else
            {
                animationList[i].SetActive(false);
            }
        }
    }

    private void RollAnim()
    {
        for (int i = 0; i < animationList.Count; i++)
        {
            if (i == 4)
            {
                animationList[i].SetActive(true);
            }
            else
            {
                animationList[i].SetActive(false);
            }
        }
    }

    private void BackAnim()
    {
        for (int i = 0; i < animationList.Count; i++)
        {
            if (i == 5)
            {
                animationList[i].SetActive(true);
            }
            else
            {
                animationList[i].SetActive(false);
            }
        }
    }

    private void RunBackAnim()
    {
        for (int i = 0; i < animationList.Count; i++)
        {
            if (i == 6)
            {
                animationList[i].SetActive(true);
            }
            else
            {
                animationList[i].SetActive(false);
            }
        }
    }

    private void RightStradeAnim()
    {
        for (int i = 0; i < animationList.Count; i++)
        {
            if (i == 7)
            {
                animationList[i].SetActive(true);
            }
            else
            {
                animationList[i].SetActive(false);
            }
        }
    }

    private void LeftStradeAnim()
    {
        for (int i = 0; i < animationList.Count; i++)
        {
            if (i == 8)
            {
                animationList[i].SetActive(true);
            }
            else
            {
                animationList[i].SetActive(false);
            }
        }
    }

    private void RightStradeRunAnim()
    {
        for (int i = 0; i < animationList.Count; i++)
        {
            if (i == 9)
            {
                animationList[i].SetActive(true);
            }
            else
            {
                animationList[i].SetActive(false);
            }
        }
    }

    private void LeftStradeRunAnim()
    {
        for (int i = 0; i < animationList.Count; i++)
        {
            if (i == 10)
            {
                animationList[i].SetActive(true);
            }
            else
            {
                animationList[i].SetActive(false);
            }
        }
    }
}
