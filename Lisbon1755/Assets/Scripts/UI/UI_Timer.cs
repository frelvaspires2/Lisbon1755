using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    public Slider timerSlider;
    public Text TimerText;

    //public GameObject MyObject;

    public float gameTime;

    private bool stopTimer;

    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;

       // gameTime = MyObject.GetComponent<WakeUp>().EventTimeCounter
    }

    // i don't know, could work.
    /*void SliderTimer() 
    {
        var value = timerSlider.GetComponent<Slider>().value;
        value = MyObject.GetComponent<GameData>().EventTimeCounter;

        timerSlider.GetComponent<Slider>().value = value;
    }*/

    void Update()
    {
        float time = gameTime - Time.time;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        if (time <= 0)
        {
            stopTimer = true;
        }
        if (stopTimer == false)
        {
            //again, I don't know.
            //SliderTimer(); 
            TimerText.text = textTime;
            timerSlider.value = time;
        }
            
    }
}
