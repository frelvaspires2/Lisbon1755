using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private EventsResultStats eventsResultStats;

    [SerializeField]
    private int winCount;

    [SerializeField]
    private int lossCount;

    [SerializeField]
    private Text saved;

    [SerializeField]
    private Text notSaved;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Calculate();
        SetResult();
    }

    private void Calculate()
    {
        foreach(EventResult item in eventsResultStats.EventsResult)
        {
            if(item == EventResult.Won)
            {
                winCount += 1;
            }
            else if(item == EventResult.Lost)
            {
                lossCount += 1;
            }
            else if(item == EventResult.None)
            {
                lossCount += 1;
            }
        }
    }

    private void SetResult()
    {
        saved.text = winCount.ToString();
        notSaved.text = lossCount.ToString();
    }
}
