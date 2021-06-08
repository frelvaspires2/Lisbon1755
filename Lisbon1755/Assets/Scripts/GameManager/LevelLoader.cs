using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Load the level and show it in the loading screen.
/// </summary>
public class LevelLoader : MonoBehaviour
{
    /// <summary>
    /// Access the loading screen UI gameobject.
    /// </summary>
    [SerializeField]
    private GameObject loadingScreen;

    /// <summary>
    /// Access the level load slider.
    /// </summary>
    [SerializeField]
    private Slider slider;

    /// <summary>
    /// Load the level.
    /// </summary>
    /// <param name="sceneIndex"> Index of the level to be loaded. </param>
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    /// <summary>
    /// Show the loading progress in the slider.
    /// </summary>
    /// <param name="sceneIndex"> Scene to be loaded.</param>
    /// <returns> Null.</returns>
    private IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, 
            LoadSceneMode.Single);

        loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }
}
