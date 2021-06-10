using UnityEngine;

/// <summary>
/// Set which voice style the agent will use.
/// </summary>
public class SetPanickVoice : MonoBehaviour
{
    /// <summary>
    /// Access the voice1 gameobjects.
    /// </summary>
    [SerializeField]
    private GameObject[] mVoice1;

    /// <summary>
    /// Access the voice2 gameobjects.
    /// </summary>
    [SerializeField]
    private GameObject[] fVoice2;

    /// <summary>
    /// Access the voice3 gameobjects.
    /// </summary>
    [SerializeField]
    private GameObject[] mVoice3;

    /// <summary>
    /// To be played in the first frame of the game.
    /// Initialize the voices.
    /// </summary>
    private void Awake()
    {
        InitializeVoices();
    }

    /// <summary>
    /// Initialize the voices.
    /// </summary>
    private void InitializeVoices()
    {
        TurnOff(ref mVoice1);

        TurnOff(ref fVoice2);

        TurnOff(ref mVoice3);
    }

    /// <summary>
    /// Choose a voice style.
    /// </summary>
    /// <param name="voice"> Chosen voice style.</param>
    public void ChooseVoice(PanickVoiceTypes voice)
    {
        switch(voice)
        {
            case PanickVoiceTypes.MVoice1:
                TurnOn(ref mVoice1);
                break;

            case PanickVoiceTypes.FVoice2:
                TurnOn(ref fVoice2);
                break;

            case PanickVoiceTypes.MVoice3:
                TurnOn(ref mVoice3);
                break;
        }
    }

    /// <summary>
    /// Turn off the target voice.
    /// </summary>
    /// <param name="character"> Chosen voice.</param>
    private void TurnOff(ref GameObject[] voice)
    {
        for (int i = 0; i < voice.Length; i++)
        {
            voice[i].SetActive(false);
        }
    }

    /// <summary>
    /// Turn on the target voice.
    /// </summary>
    /// <param name="character"> Chosen voice.</param>
    private void TurnOn(ref GameObject[] voice)
    {
        for (int i = 0; i < voice.Length; i++)
        {
            voice[i].SetActive(true);
        }
    }
}
