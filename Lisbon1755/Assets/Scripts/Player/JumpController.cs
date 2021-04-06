using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private void Start()
    {
        animator.Play("jumpV1");
    }

}
