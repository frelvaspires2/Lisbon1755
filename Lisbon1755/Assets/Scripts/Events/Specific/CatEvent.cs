using System.Collections;
using UnityEngine;

/// <summary>
/// Cat event spicific stuff.
/// </summary>
public class CatEvent : MonoBehaviour
{
    /// <summary>
    /// Access the EventsManager script.
    /// </summary>
    [SerializeField]
    private EventsManager eventManager;

    /// <summary>
    /// Access the cat in danger gameobject.
    /// </summary>
    [SerializeField]
    private GameObject catInDanger;

    /// <summary>
    /// Access the dying cat gameobject.
    /// </summary>
    [SerializeField]
    private GameObject dyingCat;

    /// <summary>
    /// Access the cat in safety gameobject.
    /// </summary>
    [SerializeField]
    private GameObject catSafe;

    /// <summary>
    /// Access the cat lady scared gameobject.
    /// </summary>
    [SerializeField]
    private GameObject catLadyScared;

    /// <summary>
    /// Access the cat lady thankful gameobject.
    /// </summary>
    [SerializeField]
    private GameObject catLadyThankful;

    /// <summary>
    /// Access the sad cat lady gameobject.
    /// </summary>
    [SerializeField]
    private GameObject catLadySad;

    /// <summary>
    /// Access the cat animator.
    /// </summary>
    [SerializeField]
    private Animator catAnim;

    /// <summary>
    /// Set the cat's animation time.
    /// </summary>
    [SerializeField]
    private float catAnimTime;

    /// <summary>
    /// Set the animation name to be played.
    /// </summary>
    [SerializeField]
    private string animName;

    /// <summary>
    /// Set the time for the NPCs to disappear.
    /// </summary>
    [SerializeField]
    private float timeToDisappear = 5f;

    /// <summary>
    /// Access the ScoreStats scriptableobject.
    /// </summary>
    [SerializeField]
    private ScoreStats scoreStats;

    /// <summary>
    /// Checks whether the player has won.
    /// </summary>
    private bool hasWon;

    /// <summary>
    /// Checks whether the animation has finished..
    /// </summary>
    private bool hasAnimRun;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize variables.
    /// </summary>
    private void Start()
    {
        hasWon = false;
        hasAnimRun = false;
    }

    /// <summary>
    /// To be played in every frame of the game.
    /// Run the state machine.
    /// </summary>
    private void Update()
    {
        STM();
    }

    /// <summary>
    /// Run the state machine.
    /// </summary>
    private void STM()
    {
        switch (eventManager.GetEventResult)
        {
            case EventResult.None:
                NoneState();
                break;
            case EventResult.Won:
                if (!hasWon)
                {
                    scoreStats.Level2Score += 1;
                    hasWon = true;
                }
                WonState();
                break;
            case EventResult.Lost:
                LostState();
                break;
        }
    }

    /// <summary>
    /// State when nothing happened yet.
    /// </summary>
    private void NoneState()
    {
        catInDanger.SetActive(true);
        catSafe.SetActive(false);
        catLadyScared.SetActive(true);
        catLadyThankful.SetActive(false);
        catLadySad.SetActive(false);
        dyingCat.SetActive(false);
    }

    /// <summary>
    /// State when the player won.
    /// </summary>
    private void WonState()
    {
        if(!hasAnimRun)
        {
            StartCoroutine(CatAnim());
            hasAnimRun = true;
        }

        StartCoroutine(Disappear(catSafe, catLadyThankful));
    }

    /// <summary>
    /// State when the player lost.
    /// </summary>
    private void LostState()
    {
        catInDanger.SetActive(false);
        catSafe.SetActive(false);
        catLadyScared.SetActive(false);
        catLadyThankful.SetActive(false);
        catLadySad.SetActive(true);
        dyingCat.SetActive(true);
    }

    /// <summary>
    /// Disappear the NPCs.
    /// </summary>
    /// <param name="gameObject1"> The cat lady.</param>
    /// <param name="gameObject2"> The cat.</param>
    /// <returns> Wait for seconds.</returns>
    private IEnumerator Disappear(GameObject gameObject1, 
        GameObject gameObject2)
    {
        WaitForSeconds wfs = new WaitForSeconds(timeToDisappear);

        yield return wfs;

        Destroy(gameObject1);
        Destroy(gameObject2);

        StopCoroutine(Disappear(gameObject1, gameObject2));
    }

    /// <summary>
    /// Play the cat animation.
    /// </summary>
    /// <returns> Wait for seconds.</returns>
    private IEnumerator CatAnim()
    {
        WaitForSeconds wfs1 = new WaitForSeconds(0);

        WaitForSeconds wfs2 = new WaitForSeconds(catAnimTime);

        yield return wfs1;

        catAnim.Play(animName);

        yield return wfs2;

        catInDanger.SetActive(false);
        dyingCat.SetActive(false);
        if (catSafe != null)
        {
            catSafe.SetActive(true);
        }
        catLadyScared.SetActive(false);
        if (catSafe != null)
        {
            catLadyThankful.SetActive(true);
        }
        if (catLadySad != null)
        {
            catLadySad.SetActive(false);
        }

        StopCoroutine(CatAnim());
    }
}
