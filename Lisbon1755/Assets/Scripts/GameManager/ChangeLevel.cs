using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    private int scene;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private bool isEnd;

    private void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            if (!isEnd)
            {
                SceneManager.LoadScene(scene + 1);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
