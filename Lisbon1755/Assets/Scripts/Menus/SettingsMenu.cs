using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// Manage the settings menu.
/// </summary>
public class SettingsMenu : MonoBehaviour
{
    /// <summary>
    /// Access the audio mixer.
    /// </summary>
    public AudioMixer audioMixer;

    /// <summary>
    /// Access the dropdown UI.
    /// </summary>
    public Dropdown resolutionDropdown;

    /// <summary>
    /// Access all possible resolutions.
    /// </summary>
    private Resolution[] resolutions;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize stuff.
    /// </summary>
    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + 
                resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        audioMixer.SetFloat("volume", 0f);
    }

    /// <summary>
    /// Set the resolutions.
    /// </summary>
    /// <param name="resolutionIndex"> Index of the chosen reoslution.</param>
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, 
            Screen.fullScreen);
    }

    /// <summary>
    /// Set the volume of the game.
    /// </summary>
    /// <param name="volume"> Volume value.</param>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    /// <summary>
    /// Set the quality of the game.
    /// </summary>
    /// <param name="qualityIndex"> Index of the chosen quality.</param>
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    /// <summary>
    /// Set the game full screen.
    /// </summary>
    /// <param name="isFullscreen"> Check whether the player wants to set the
    /// game full screen.</param>
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
        
}
