using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GotHitScreen : MonoBehaviour
{
    public GameObject m_GotHitScreen;
    public GameObject MyObject;

    void Start()
    {
        
    }

    void gotHurt()
    {
        var color = m_GotHitScreen.GetComponent<Image>().color;
        color.a = 0.8f;

        m_GotHitScreen.GetComponent<Image>().color = color;
    }

    void Update()
    {
        if (MyObject.GetComponent<GameData>().IsInjured == true)
            {
                gotHurt();
            }

        if (m_GotHitScreen != null)
        {
            if (m_GotHitScreen.GetComponent<Image>().color.a > 0)
            {
                var color = m_GotHitScreen.GetComponent<Image>().color;
                color.a -= 0.01f;
                m_GotHitScreen.GetComponent<Image>().color = color;
            }
        }
    }
}
 