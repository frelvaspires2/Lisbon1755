using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_QTE : MonoBehaviour
{
    public float fillAmount = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("MouseClick"))
        {
            //Debug.Log("press");
            fillAmount += .2f;
        }
        GetComponent<Image>().fillAmount = fillAmount;
    }
}