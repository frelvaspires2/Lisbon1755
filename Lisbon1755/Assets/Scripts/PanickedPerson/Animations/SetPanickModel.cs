using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPanickModel : MonoBehaviour
{
    [SerializeField]
    private PanickModelTypes panickModelTypes;

    [SerializeField]
    private GameObject[] prototype;

    [SerializeField]
    private GameObject[] character1;

    [SerializeField]
    private GameObject[] character2;

    [SerializeField]
    private GameObject[] character3;

    [SerializeField]
    private GameObject[] character4;

    private void Start()
    {
        InitializeModels();
        SetModel();
    }

    private void InitializeModels()
    {
        for (int i = 0; i < prototype.Length; i++)
        {
            prototype[i].SetActive(false);
        }

        for (int i = 0; i < character1.Length; i++)
        {
            character1[i].SetActive(false);
        }

        for (int i = 0; i < character2.Length; i++)
        {
            character2[i].SetActive(false);
        }

        for (int i = 0; i < character3.Length; i++)
        {
            character3[i].SetActive(false);
        }

        for (int i = 0; i < character4.Length; i++)
        {
            character4[i].SetActive(false);
        }
    }

    private void SetModel()
    {
        switch(panickModelTypes)
        {
            case PanickModelTypes.Character1:
                for (int i = 0; i < character1.Length; i++)
                {
                    character1[i].SetActive(true);
                }
                break;

            case PanickModelTypes.Character2:
                for (int i = 0; i < character2.Length; i++)
                {
                    character2[i].SetActive(true);
                }
                break;

            case PanickModelTypes.Character3:
                for (int i = 0; i < character3.Length; i++)
                {
                    character3[i].SetActive(true);
                }
                break;

            case PanickModelTypes.Character4:
                for (int i = 0; i < character4.Length; i++)
                {
                    character4[i].SetActive(true);
                }
                break;
        }
    }
}
