using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private ScoreStats scoreStats;

    [SerializeField]
    private int winCount;

    [SerializeField]
    private int lossCount;

    [SerializeField]
    private Text saved;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Calculate();
        SetResult();
    }

    private void Calculate()
    {
        winCount = scoreStats.FinalScore;
    }

    private void SetResult()
    {
        saved.text = winCount.ToString();
    }
}
