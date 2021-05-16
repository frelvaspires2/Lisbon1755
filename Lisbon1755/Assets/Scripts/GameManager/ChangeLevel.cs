using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    private int scene;

    [SerializeField]
    private GameStats gameStats;

    [SerializeField]
    private SaveGame saveGame;

    [SerializeField]
    private ScoreStats scoreStats;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private bool isEnd;

    private void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }

    private void SaveGame()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            gameStats.GameStatsDic.Add(new SaveData(1, true, scoreStats.Level1Score));
        }
        else if(SceneManager.GetActiveScene().name == "Level2")
        {
            gameStats.GameStatsDic.Add(new SaveData(2, true, scoreStats.Level2Score));
        }

        //Debug.Log("Tamanho do dicionário: " + gameStats.GameStatsDic.Count);

        saveGame.SaveTheGame(gameStats.GameStatsDic);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            if (!isEnd)
            {
                SaveGame();
                SceneManager.LoadScene(scene + 1);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
