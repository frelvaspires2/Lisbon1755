using UnityEngine;

public class BlockArea : MonoBehaviour
{
    [SerializeField]
    private Collider blocker;

    [SerializeField]
    private PlayAnim playAnim;

    private void Start()
    {
        blocker.isTrigger = true;
    }

    private void Update()
    {
        if (playAnim.IsDone)
        {
            Block();
        }
    }

    private void Block()
    {
        blocker.isTrigger = false;
    }
}

