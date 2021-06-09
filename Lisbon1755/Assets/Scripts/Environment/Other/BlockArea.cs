using UnityEngine;

/// <summary>
/// Area blocker used in falling buildings.
/// </summary>
public class BlockArea : MonoBehaviour
{
    /// <summary>
    /// Access the blocker's collider.
    /// </summary>
    [SerializeField]
    private Collider blocker;

    /// <summary>
    /// Access the PlayAnim script.
    /// </summary>
    [SerializeField]
    private PlayAnim playAnim;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Set the collider trigger to true.
    /// </summary>
    private void Start()
    {
        blocker.isTrigger = true;
    }

    /// <summary>
    /// To be played in every frame of the game.
    /// Block the area if the animation is done.
    /// </summary>
    private void Update()
    {
        if (playAnim.IsDone)
        {
            Block();
        }
    }

    /// <summary>
    /// Block the area.
    /// </summary>
    private void Block()
    {
        blocker.isTrigger = false;
    }
}

