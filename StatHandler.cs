using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatHandler : MonoBehaviour
{

    public Slider HealthSlider;

    public void setHealth(int health)
    {
        HealthSlider.value = health;
    }

    public void setMaxHealth(int health)
    {
        HealthSlider.maxValue = health;
        HealthSlider.value = health;
    }
}
