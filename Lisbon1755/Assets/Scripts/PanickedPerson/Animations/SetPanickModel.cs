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

    private void Start()
    {
        for(int i = 0; i < prototype.Length; i++)
        {
            prototype[i].SetActive(false);
        }

        for (int i = 0; i < character1.Length; i++)
        {
            character1[i].SetActive(false);
        }

        SetModel();
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
        }
    }
}
