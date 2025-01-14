using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider; 

    public void TakeDamage(float damage)
    {
        if(slider != null)
        {
            slider.value -= damage;
        }
    }

    public void setHealth(float maxHealth)
    {
        slider.value = PlayerPrefs.GetFloat("Health", maxHealth);
    }
}
