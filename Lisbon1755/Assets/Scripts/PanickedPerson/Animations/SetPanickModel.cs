using UnityEngine;

/// <summary>
/// Setup the character for the Panicked person.
/// </summary>
public class SetPanickModel : MonoBehaviour
{
    /// <summary>
    /// Access the character types enum.
    /// </summary>
    [SerializeField]
    private PanickModelTypes panickModelTypes;

    /// <summary>
    /// Access the prototype characters.
    /// </summary>
    [SerializeField]
    private GameObject[] prototype;

    /// <summary>
    /// Access the character1 characters.
    /// </summary>
    [SerializeField]
    private GameObject[] character1;

    /// <summary>
    /// Access the character2 characters.
    /// </summary>
    [SerializeField]
    private GameObject[] character2;

    /// <summary>
    /// Access the character3 characters.
    /// </summary>
    [SerializeField]
    private GameObject[] character3;

    /// <summary>
    /// Access the character4 characters.
    /// </summary>
    [SerializeField]
    private GameObject[] character4;

    /// <summary>
    /// Access the character5 characters.
    /// </summary>
    [SerializeField]
    private GameObject[] character5;

    /// <summary>
    /// Access the character6 characters.
    /// </summary>
    [SerializeField]
    private GameObject[] character6;

    /// <summary>
    /// To be played in the first frame.
    /// Initialize and set up the characters.
    /// </summary>
    private void Start()
    {
        InitializeCharacters();
        ChooseCharacter();
        SetCharacter();
    }

    /// <summary>
    /// Initialize the characters.
    /// </summary>
    private void InitializeCharacters()
    {
        TurnOff(ref prototype);

        TurnOff(ref character1);

        TurnOff(ref character2);

        TurnOff(ref character3);

        TurnOff(ref character4);

        TurnOff(ref character5);

        TurnOff(ref character6);
    }

    /// <summary>
    /// Choose a random character.
    /// </summary>
    private void ChooseCharacter()
    {
        int rndCharacter = Random.Range(0, 6);

        switch(rndCharacter)
        {
            case 0:
                panickModelTypes = PanickModelTypes.Character1;
                break;

            case 1:
                panickModelTypes = PanickModelTypes.Character2;
                break;

            case 2:
                panickModelTypes = PanickModelTypes.Character3;
                break;

            case 3:
                panickModelTypes = PanickModelTypes.Character4;
                break;

            case 4:
                panickModelTypes = PanickModelTypes.Character5;
                break;

            case 5:
                panickModelTypes = PanickModelTypes.Character6;
                break;
        }
    }

    /// <summary>
    /// Set up the characters.
    /// </summary>
    private void SetCharacter()
    {
        switch(panickModelTypes)
        {
            case PanickModelTypes.Character1:
                TurnOn(ref character1);
                break;

            case PanickModelTypes.Character2:
                TurnOn(ref character2);
                break;

            case PanickModelTypes.Character3:
                TurnOn(ref character3);
                break;

            case PanickModelTypes.Character4:
                TurnOn(ref character4);
                break;

            case PanickModelTypes.Character5:
                TurnOn(ref character5);
                break;

            case PanickModelTypes.Character6:
                TurnOn(ref character6);
                break;
        }
    }

    /// <summary>
    /// Turn off the target character.
    /// </summary>
    /// <param name="character"> Chosen character.</param>
    private void TurnOff(ref GameObject[] character)
    {
        for(int i = 0; i < character.Length; i++)
        {
            character[i].SetActive(false);
        }
    }

    /// <summary>
    /// Turn on the target character.
    /// </summary>
    /// <param name="character"> Chosen target.</param>
    private void TurnOn(ref GameObject[] character)
    {
        for (int i = 0; i < character.Length; i++)
        {
            character[i].SetActive(true);
        }
    }
}
