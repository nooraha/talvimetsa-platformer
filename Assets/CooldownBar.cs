using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{


    public Slider cooldownSlider;

    public void SetCooldown(float cooldown)
    {
        cooldownSlider.value = cooldown;
    }

    public void SetMaxCooldown(float cooldown)
    {
        cooldownSlider.maxValue = cooldown;
        cooldownSlider.value = cooldown;
    }
}
