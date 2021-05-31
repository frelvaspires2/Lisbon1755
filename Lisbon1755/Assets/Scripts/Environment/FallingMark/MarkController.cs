using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controller of the warning marks in falling buildings.
/// </summary>
public class MarkController : MonoBehaviour
{
    /// <summary>
    /// Access the MarkStats struct.
    /// </summary>
    [SerializeField]
    private MarkStats[] markStats;

    /// <summary>
    /// Dictionary of marks.
    /// </summary>
    private Dictionary<int, MarkStats> markDic;

    /// <summary>
    /// To be played in the first frame of the game.
    /// </summary>
    private void Start()
    {
        Setup();
        StartMarks();
    }

    /// <summary>
    /// Setup the dictionary.
    /// </summary>
    private void Setup()
    {
        markDic = new Dictionary<int, MarkStats>();

        for(int i = 0; i < markStats.Length; i++)
        {
            markStats[i].Mark.SetActive(false);
            markDic.Add(i, markStats[i]);
        }
    }

    /// <summary>
    /// Start the marks routine.
    /// </summary>
    private void StartMarks()
    {
        for(int i = 0; i < markDic.Count; i++)
        {
            StartCoroutine(MarkRoutine(markDic[i].TimeToStart,
                markDic[i].TimeToEnd, markDic[i].Mark));
        }
    }

    /// <summary>
    /// Show the marks routine.
    /// </summary>
    /// <param name="start"> Time to start showing the mark. </param>
    /// <param name="end"> Time to stop showing the mark. </param>
    /// <param name="mark"> Mark's gameobject. </param>
    /// <returns> Wait for seconds. </returns>
    private IEnumerator MarkRoutine(float start, float end, GameObject mark)
    {
        WaitForSeconds wfs1 = new WaitForSeconds(start);
        WaitForSeconds wfs2 = new WaitForSeconds(end);

        yield return wfs1;

        mark.SetActive(true);

        yield return wfs2;

        mark.SetActive(false);

        StopCoroutine(MarkRoutine(start, end, mark));
    }
}
