using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EnergyBar : MonoBehaviour
{
    public Slider energyBar;
    public GameObject MyObject;

    private int maxEnergy = 50;
    private int currentEnergy;

    public static UI_EnergyBar instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.maxValue = maxEnergy;
        energyBar.value = maxEnergy;
    }

    void SliderEnergy()
    {
        var value = energyBar.GetComponent<Slider>().value;
        value = MyObject.GetComponent<GameData>().Energy;

        energyBar.GetComponent<Slider>().value = value;
    }

    void Update()
    {
        if (MyObject.GetComponent<GameData>().Energy > 0)
        {
            SliderEnergy();
        }
        else
        {
            Debug.Log("Not enough Energy");
        }
    }
}