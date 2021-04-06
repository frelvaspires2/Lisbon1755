﻿using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private GameObject[] animations;

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
        animations[0].SetActive(true);
        animations[1].SetActive(false);
        animations[2].SetActive(false);
        animations[3].SetActive(false);
        animations[4].SetActive(false);
        animations[5].SetActive(false);
        animations[6].SetActive(false);
        animations[7].SetActive(false);
        animations[8].SetActive(false);
        animations[9].SetActive(false);
        animations[10].SetActive(false);
    }

    private void WalkAnim()
    {
        animations[0].SetActive(false);
        animations[1].SetActive(true);
        animations[2].SetActive(false);
        animations[3].SetActive(false);
        animations[4].SetActive(false);
        animations[5].SetActive(false);
        animations[6].SetActive(false);
        animations[7].SetActive(false);
        animations[8].SetActive(false);
        animations[9].SetActive(false);
        animations[10].SetActive(false);
    }

    private void RunAnim()
    {
        animations[0].SetActive(false);
        animations[1].SetActive(false);
        animations[2].SetActive(true);
        animations[3].SetActive(false);
        animations[4].SetActive(false);
        animations[5].SetActive(false);
        animations[6].SetActive(false);
        animations[7].SetActive(false);
        animations[8].SetActive(false);
        animations[9].SetActive(false);
        animations[10].SetActive(false);
    }

    private void JumpAnim()
    {
        animations[0].SetActive(false);
        animations[1].SetActive(false);
        animations[2].SetActive(false);
        animations[3].SetActive(true);
        animations[4].SetActive(false);
        animations[5].SetActive(false);
        animations[6].SetActive(false);
        animations[7].SetActive(false);
        animations[8].SetActive(false);
        animations[9].SetActive(false);
        animations[10].SetActive(false);
    }

    private void RollAnim()
    {
        animations[0].SetActive(false);
        animations[1].SetActive(false);
        animations[2].SetActive(false);
        animations[3].SetActive(false);
        animations[4].SetActive(true);
        animations[5].SetActive(false);
        animations[6].SetActive(false);
        animations[7].SetActive(false);
        animations[8].SetActive(false);
        animations[9].SetActive(false);
        animations[10].SetActive(false);
    }

    private void BackAnim()
    {
        animations[0].SetActive(false);
        animations[1].SetActive(false);
        animations[2].SetActive(false);
        animations[3].SetActive(false);
        animations[4].SetActive(false);
        animations[5].SetActive(true);
        animations[6].SetActive(false);
        animations[7].SetActive(false);
        animations[8].SetActive(false);
        animations[9].SetActive(false);
        animations[10].SetActive(false);
    }

    private void RunBackAnim()
    {
        animations[0].SetActive(false);
        animations[1].SetActive(false);
        animations[2].SetActive(false);
        animations[3].SetActive(false);
        animations[4].SetActive(false);
        animations[5].SetActive(false);
        animations[6].SetActive(true);
        animations[7].SetActive(false);
        animations[8].SetActive(false);
        animations[9].SetActive(false);
        animations[10].SetActive(false);
    }

    private void RightStradeAnim()
    {
        animations[0].SetActive(false);
        animations[1].SetActive(false);
        animations[2].SetActive(false);
        animations[3].SetActive(false);
        animations[4].SetActive(false);
        animations[5].SetActive(false);
        animations[6].SetActive(false);
        animations[7].SetActive(true);
        animations[8].SetActive(false);
        animations[9].SetActive(false);
        animations[10].SetActive(false);
    }

    private void LeftStradeAnim()
    {
        animations[0].SetActive(false);
        animations[1].SetActive(false);
        animations[2].SetActive(false);
        animations[3].SetActive(false);
        animations[4].SetActive(false);
        animations[5].SetActive(false);
        animations[6].SetActive(false);
        animations[7].SetActive(false);
        animations[8].SetActive(true);
        animations[9].SetActive(false);
        animations[10].SetActive(false);
    }

    private void RightStradeRunAnim()
    {
        animations[0].SetActive(false);
        animations[1].SetActive(false);
        animations[2].SetActive(false);
        animations[3].SetActive(false);
        animations[4].SetActive(false);
        animations[5].SetActive(false);
        animations[6].SetActive(false);
        animations[7].SetActive(false);
        animations[8].SetActive(false);
        animations[9].SetActive(true);
        animations[10].SetActive(false);
    }

    private void LeftStradeRunAnim()
    {
        animations[0].SetActive(false);
        animations[1].SetActive(false);
        animations[2].SetActive(false);
        animations[3].SetActive(false);
        animations[4].SetActive(false);
        animations[5].SetActive(false);
        animations[6].SetActive(false);
        animations[7].SetActive(false);
        animations[8].SetActive(false);
        animations[9].SetActive(false);
        animations[10].SetActive(true);
    }
}
