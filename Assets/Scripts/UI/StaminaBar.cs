using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : ResourceBars
{
    public EntityData Entity;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = Entity.maxStamina;
        slider.value = Entity.currentStamina;
    }

    public override void UpdateUI() 
    {
        slider.value = Entity.currentStamina;
    }
}
